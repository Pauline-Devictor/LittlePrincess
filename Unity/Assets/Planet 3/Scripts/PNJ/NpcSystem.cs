using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NpcSystem : MonoBehaviour
{
    private bool _playerDetection = false;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public bool dialogActive;
    public string[] dialog;
    private int _index = 0;
    private bool _hasTalked = false;
    private bool _hasBeenDefeated = false;
    public bool inFight = false;
    public string b4Fightdialog;
    public string[] afterFightdialog;
    
    public delegate void OnBattleRequested();
    public static event OnBattleRequested BattleRequested;
    
    public PokemonBase pokemon;

    // Update is called once per frame
    void Update()
    {
        if (_playerDetection && Input.GetKeyDown(KeyCode.F) && _index< dialog.Length && _hasTalked == false)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                dialogBox.SetActive(true);
                NextLine();
            }
            //print("Dialogue Started");
        }

        else if (_playerDetection && Input.GetKeyDown(KeyCode.Space) &&  dialogBox.activeInHierarchy && _hasTalked == false)
        {
            if (_index < dialog.Length)
            {
                NextLine();
            }
            else
            {
                EndDialogue();
                _hasTalked = true;
            }
        }

        if (_playerDetection && Input.GetKeyDown(KeyCode.F) && _hasTalked && !_hasBeenDefeated)
        {
            dialogText.text = b4Fightdialog;
            inFight = true;
            Wait();
            RequestBattle();
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player") || other.name.Equals("Unity_Chan_humanoid"))
        {
            _playerDetection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _playerDetection = false;
        dialogBox.SetActive(false);
    }
    
    //------DialoguePart-----------



   /* void TypeLine()
    {
        dialogText.text = dialog[index];
        if (index<dialog.Length)
        {
            dialogText.text = dialog[index];
        }
        else
        {
            dialogText.text = string.Empty;
            dialogBox.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
        }
        
    }*/
    
    void NextLine()
    {
        //print(dialog.Length);
        //print(index);
       if (_index < dialog.Length)
       {
           dialogText.text = dialog[_index];
           _index++;
       }
    }

    void EndDialogue()
    {
        dialogBox.SetActive(false);
        dialogText.text = string.Empty;
        _index = 0;
    }
    
    void RequestBattle()
    {
        BattleRequested?.Invoke(); 
        inFight = false;
    }
}
