using System.Collections;
using UnityEngine;

public class Planet3SceneManager : MonoBehaviour
{
    public GameObject town;
    public GameObject battle;
    
    private GameObject _currentPnj;

    public BattleSystem battleSystem;

    public delegate void OnBattleStarted();
    public static event OnBattleStarted BattleStarted;
    
    public delegate void OnBattleOver();
    public static event OnBattleOver BattleOver;
    
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        BattleSystem.BattleFinished += SwitchToTown;
        BattleSystem.IsDefeated += Defeated;

        NpcSystem.BattleRequested += SwitchToBattle;
    }

    void Defeated()
    {
        _currentPnj = battleSystem.currentPnj;
        _currentPnj.GetComponent<NpcSystem>().SetHasBeenDefeated();
        SwitchToTown();
    }

    void SwitchToTown()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        battle.SetActive(false);
        town.SetActive(true);
        Wait();
        BattleOver?.Invoke();

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
    void SwitchToBattle()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        town.SetActive(false);
        battle.SetActive(true);
        BattleStarted?.Invoke();
    }
}
