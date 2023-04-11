using TMPro;
using UnityEngine;

public class IntroDetectorP2 : MonoBehaviour
{
    public GameObject dialogueBox;

    public TextMeshProUGUI dialogueText;

    public string[] introductionDialogue;

    private bool _hasTalked;
    private bool _detectPlayer;
    
    

    private int _index;
    // Start is called before the first frame update
    void Start()
    {
        _index = 0;
        _hasTalked = false;
        _detectPlayer = false;
    }

    private void Update()
    {
        if (_detectPlayer && !_hasTalked)
        {
            if ((Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0)) && _index< introductionDialogue.Length)
            {
                NextLine();
            }

            if (_index >= introductionDialogue.Length)
            {
                EndDialogue();
                _hasTalked = true;
            }
            
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player") || other.name.Equals("Unity_Chan_humanoid"))
        {
            _detectPlayer = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        _detectPlayer = false;
    }

    void NextLine()
    {
        if (_index < introductionDialogue.Length)
        {
            dialogueText.text = introductionDialogue[_index];
            _index++;
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        dialogueText.text = string.Empty;
        _index = 0;
    }
}
