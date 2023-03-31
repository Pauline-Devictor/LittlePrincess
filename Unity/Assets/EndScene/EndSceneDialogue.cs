using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneDialogue : MonoBehaviour
{
    public String[] dialog;

    public String[] speaker;
    
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;

    private int _index = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F) ||Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && _index< dialog.Length)
        {
            NextLine();
        }

        if ((Input.GetKeyDown(KeyCode.F) ||Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && _index >= dialog.Length)
        {
            LaunchCredit();
        }
    }
    
    void NextLine()
    {
        //print(dialog.Length);
        //print(index);
        if (_index < dialog.Length)
        {
            dialogText.text = dialog[_index];
            nameText.text = speaker[_index];
            _index++;
        }
    }

    void LaunchCredit()
    {
        SceneManager.LoadScene(4);
    }
}
