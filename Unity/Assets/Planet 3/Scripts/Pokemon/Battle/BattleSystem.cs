using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	PokeBattle playerUnit;
	PokeBattle enemyUnit;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

	public Button attackButton;
	static bool hasWon = false;

	
	//Gestion de la fin d'un combat avec un event
	public delegate void OnBattleFinished();
	public static event OnBattleFinished BattleFinished;

	private void Start()
	{
		Planet3SceneManager.BattleStarted += newBattle;
		newBattle();
	}

	public void newBattle()
    {
		state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<PokeBattle>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<PokeBattle>();

		dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);
		hasWon = false;

		yield return new WaitForSeconds(2f);
		

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		attackButton.interactable = false;
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
			hasWon = true;
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
			hasWon = false;
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
		if (state != BattleState.PLAYERTURN)
			return;
		
		StartCoroutine(PlayerAttack());
	}
}
