using TMPro;
using UnityEngine;

public class IntroDetectorP2 : MonoBehaviour
{
    public GameObject dialogueBox;

    public TextMeshProUGUI dialogueText;

    public string[] introductionDialogue;

    private bool _hasTalked;
    private bool _detectPlayer;

    public GameObject player;
    public GameObject camera;
    public GameObject unityChan;

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
            Debug.Log("Player detected");
            if (_index < introductionDialogue.Length && _index == 0)
            {
                player.GetComponent<PlayerMovement>().enabled = false;
                camera.GetComponent<HorizontalMouseLook>().enabled = false;
                unityChan.GetComponent<PlayerControllerPlanet3>().enabled = false;
                Debug.Log("------------------------ First line");
                NextLine();
            }
            else if ((Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0)) && _index < introductionDialogue.Length)
            {
                Debug.Log("------------------------ Next line");
                NextLine();
            }
            else if ((Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0)) && _index == introductionDialogue.Length)
            {
                Debug.Log("------------------------ End dialogue");
                EndDialogue();
                player.GetComponent<PlayerMovement>().enabled = true;
                camera.GetComponent<HorizontalMouseLook>().enabled = true;
                unityChan.GetComponent<PlayerControllerPlanet3>().enabled = true;
                _hasTalked = true;
            }
            
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
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
            dialogueBox.SetActive(true);
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
