using UnityEngine;

public class Planet3SceneManager : MonoBehaviour
{
    public GameObject town;
    public GameObject battle;
    
    public delegate void OnBattleStarted();
    public static event OnBattleStarted BattleStarted;

    private void Start()
    {
        BattleSystem.BattleFinished += SwitchToTown;
        NPCSystem.BattleRequested += SwitchToBattle;
    }

    void SwitchToTown()
    {
        battle.SetActive(false);
        town.SetActive(true);
        
    }
    void SwitchToBattle()
    {
        town.SetActive(false);
        battle.SetActive(true);
        BattleStarted?.Invoke();
    }
}
