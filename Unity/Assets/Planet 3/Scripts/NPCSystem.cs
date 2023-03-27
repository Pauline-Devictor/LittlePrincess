using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCSystem : MonoBehaviour
{
    private bool player_detection = false;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public bool dialogActive;
    public string[] dialog;
    private int index = 0;
    private bool hasTalked = false;
    private bool hasBeenDefeated = false;
    public string b4Fightdialog;
    public string[] afterFightdialog;
    
    public delegate void OnBattleRequested();
    public static event OnBattleRequested BattleRequested;

    // Update is called once per frame
    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.F) && index< dialog.Length && hasTalked == false)
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

        else if (player_detection && Input.GetKeyDown(KeyCode.Space) &&  dialogBox.activeInHierarchy && hasTalked == false)
        {
            if (index < dialog.Length)
            {
                NextLine();
            }
            else
            {
                EndDialogue();
                hasTalked = true;
            }
        }

        if (player_detection && Input.GetKeyDown(KeyCode.F) && hasTalked && !hasBeenDefeated)
        {
            dialogText.text = b4Fightdialog;
            wait();
            RequestBattle();
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player") || other.name.Equals("Unity_Chan_humanoid"))
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
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
       if (index < dialog.Length)
       {
           dialogText.text = dialog[index];
           index++;
       }
    }

    void EndDialogue()
    {
        dialogBox.SetActive(false);
        dialogText.text = string.Empty;
        index = 0;
    }
    
    void RequestBattle()
    {
        BattleRequested?.Invoke();
    }
}
