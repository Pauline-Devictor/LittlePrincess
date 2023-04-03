using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
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
	[FormerlySerializedAs("_currentPnj")] public GameObject currentPnj;
	
	public GameObject[] pokeList;
	private GameObject _currentEnemyPoke;


	//Gestion de la fin d'un combat avec un event
	public delegate void OnBattleFinished();
	public static event OnBattleFinished BattleFinished;
	
	public delegate void HasBeenDefeated();
	public static event HasBeenDefeated IsDefeated;
	

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
		currentPnj = null;
		foreach (var pnj in pnjList)
		{
			if (pnj.GetComponent<NpcSystem>().inFight)
			{
				currentPnj = pnj;
			}
		}
		
		GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
		_playerUnit = playerGo.GetComponent<PokeBattle>();


		String enemy = currentPnj.GetComponent<NpcSystem>().pokemon.Name;
		foreach (var poke in pokeList)
		{
			if (poke.GetComponent<PokeBattle>().unitName == enemy)
			{
				_currentEnemyPoke = poke;
			}
			
		}
		//GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
		GameObject enemyGo = Instantiate(_currentEnemyPoke, enemyBattleStation);
		_enemyUnit = enemyGo.GetComponent<PokeBattle>();
		//Idle
		//_currentEnemyPoke.GetComponent<Animator>().Play("Idle");
		//_currentEnemyPoke.GetComponent<Animator>().SetBool("Attack",true);

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
		cleanPokemonOnBattle();
		currentPnj.GetComponent<NpcSystem>().inFight = false;
		if(state == BattleState.Won)
		{
			dialogueText.text = "You won the battle!";
			IsDefeated?.Invoke();
			//	hasWon = true;
		} else if (state == BattleState.Lost)
		{
			dialogueText.text = "You were defeated.";
			BattleFinished?.Invoke();
		//	hasWon = false;
		}

		cleanPokemonOnBattle();
		currentPnj.GetComponent<NpcSystem>().inFight = false;

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

	private void cleanPokemonOnBattle()
	{
		for (int i = enemyBattleStation.transform.childCount - 1; i >= 0; i--)
		{
			// Récupération de l'enfant à l'index i
			GameObject child = enemyBattleStation.transform.GetChild(i).gameObject;

			// Suppression de l'enfant
			Destroy(child);
		}
		
		for (int i = playerBattleStation.transform.childCount - 1; i >= 0; i--)
		{
			// Récupération de l'enfant à l'index i
			GameObject child = playerBattleStation.transform.GetChild(i).gameObject;

			// Suppression de l'enfant
			Destroy(child);
		}

	}

}
