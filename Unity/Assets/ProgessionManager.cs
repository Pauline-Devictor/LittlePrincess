using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgessionManager : MonoBehaviour
{
    public NpcSystem[] npcSystems;
    private int _battleCounter = 0;
    private bool _endGameStart = false;
    private bool _dialogueStart = false;
    public string[] dialog;
    private int _index = 0;
    
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    

    private void Start()
    {
        
        Planet3SceneManager.BattleOver += CheckBattleStatus;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && _index < dialog.Length && _dialogueStart)
        {
            NextLine();
        }

        if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && _index == dialog.Length && _dialogueStart)
        {
            SceneManager.LoadScene(5);
        }
    }


    private void CheckBattleStatus()
    {
        _battleCounter = 0;
        foreach (var npc in npcSystems)
        {
            if (npc.GetHasBeenDefeated())
            {
                _battleCounter += 1;
            }
        }

        if (_battleCounter == npcSystems.Length)
        { 
           
            _endGameStart = true;
            EndGameStart();
            
        }
    }

    private void EndGameStart()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _dialogueStart = true;
        dialogBox.SetActive(true);
        NextLine();
    }
    
    void NextLine()
    {
        if (_index < dialog.Length)
        {
            dialogText.text = dialog[_index];
            _index++;
        }
    }
    
    
}
