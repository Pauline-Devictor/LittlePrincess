using UnityEngine;

public class Planet3SceneManager : MonoBehaviour
{
    public GameObject town;
    public GameObject battle;
    
    public delegate void OnBattleStarted();
    public static event OnBattleStarted BattleStarted;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        BattleSystem.BattleFinished += SwitchToTown;
        NPCSystem.BattleRequested += SwitchToBattle;
    }

    void SwitchToTown()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        battle.SetActive(false);
        town.SetActive(true);
        
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
