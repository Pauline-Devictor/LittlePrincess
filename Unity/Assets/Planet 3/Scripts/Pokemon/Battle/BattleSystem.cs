using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { Start, Playerturn, Enemyturn, Won, Lost }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	PokeBattle _playerUnit;
	PokeBattle _enemyUnit;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

	public Button attackButton;
	//static bool hasWon = false;
	
	public GameObject[] pnjList;
	private GameObject _currentPnj;


	//Gestion de la fin d'un combat avec un event
	public delegate void OnBattleFinished();
	public static event OnBattleFinished BattleFinished;

	private void Start()
	{
		Planet3SceneManager.BattleStarted += NewBattle;
		NewBattle();
	}

	public void NewBattle()
    {
		state = BattleState.Start;
		StartCoroutine(SetupBattle());
    }

	IEnumerator SetupBattle()
	{
		FindPnj();
		GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
		_playerUnit = playerGo.GetComponent<PokeBattle>();

		GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
		_enemyUnit = enemyGo.GetComponent<PokeBattle>();

		dialogueText.text = "A wild " + _enemyUnit.unitName + " approaches...";

		playerHUD.SetHUD(_playerUnit);
		enemyHUD.SetHUD(_enemyUnit);
	//	hasWon = false;

		yield return new WaitForSeconds(2f);
		

		state = BattleState.Playerturn;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		attackButton.interactable = false;
		bool isDead = _enemyUnit.TakeDamage(_playerUnit.damage);

		enemyHUD.SetHP(_enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.Won;
			EndBattle();
		} else
		{
			state = BattleState.Enemyturn;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = _enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(1f);

		bool isDead = _playerUnit.TakeDamage(_enemyUnit.damage);

		playerHUD.SetHP(_playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.Lost;
			EndBattle();
		} else
		{
			state = BattleState.Playerturn;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if(state == BattleState.Won)
		{
			dialogueText.text = "You won the battle!";
		//	hasWon = true;
		} else if (state == BattleState.Lost)
		{
			dialogueText.text = "You were defeated.";
		//	hasWon = false;
		}
		BattleFinished?.Invoke();
		
	}

	void PlayerTurn()
	{
		attackButton.interactable = true;
		dialogueText.text = "Choose an action:";
	}

	public void OnAttackButton()
	{
		if (state != BattleState.Playerturn)
			return;
		
		StartCoroutine(PlayerAttack());
	}

	private void FindPnj()
	{
		foreach (var pnj in pnjList)
		{
			if (pnj.GetComponent<NpcSystem>().inFight)
			{
				_currentPnj = pnj;
			}
		}

		_currentPnj = null;
	}
}
