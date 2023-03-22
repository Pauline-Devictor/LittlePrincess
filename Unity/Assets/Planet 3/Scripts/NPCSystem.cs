using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCSystem : MonoBehaviour
{
    private bool player_detection = false;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public bool dialogActive;
    public string[] dialog;
    private int index = 0;

    // Update is called once per frame
    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.F) && index< dialog.Length)
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

        else if (player_detection && Input.GetKeyDown(KeyCode.Space) &&  dialogBox.activeInHierarchy)
        {
            if (index < dialog.Length)
            {
                NextLine();
            }
            else
            {
                EndDialogue();
            }
        }
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
}
