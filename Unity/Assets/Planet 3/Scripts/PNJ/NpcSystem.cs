using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
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
    public GameObject dialogueHintButton;
    
    public delegate void OnBattleRequested();
    public static event OnBattleRequested BattleRequested;
    
    public PokemonBase pokemon;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    
    // Update is called once per frame
    void Update()
    {
        if ( (_playerDetection && _hasTalked == false && _index == 0) || (_playerDetection && _hasTalked && !_hasBeenDefeated))
        {
            dialogueHintButton.SetActive(true);
            
        }
        if (_playerDetection && Input.GetKeyDown(KeyCode.F) && _index< dialog.Length && _hasTalked == false)
        {
            dialogueHintButton.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            dialogBox.SetActive(true);
            NextLine();
            
            //print("Dialogue Started");
        }

        else if (_playerDetection && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) )&&  dialogBox.activeInHierarchy && _hasTalked == false)
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
            inFight = true;
            dialogueHintButton.SetActive(false);
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
           if (_index < audioClips.Length)
           {
               audioSource.clip = audioClips[_index];
               audioSource.Play();
           }
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
        inFight = true;
        BattleRequested?.Invoke(); 
    }

    public bool GetHasBeenDefeated()
    {
        return _hasBeenDefeated;
    }

    public void SetHasBeenDefeated()
    {
        _hasBeenDefeated = true;
    }
}
