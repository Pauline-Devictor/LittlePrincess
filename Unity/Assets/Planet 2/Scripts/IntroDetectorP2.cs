using TMPro;
using UnityEngine;
using System.Threading.Tasks;

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
    public GameObject NPC;
    public GameObject dialogueBoxArrivee;
    public GameObject dialogueBoxChoix;
    

    private int _index;
    // Start is called before the first frame update
    void Start()
    {
        _index = 0;
        _hasTalked = false;
        _detectPlayer = false;
        dialogueBoxChoix.GetComponent<BoxCollider>().enabled = false;
    }

    private void Update()
    {
        if (_detectPlayer && !_hasTalked)
        {

            if (_index < introductionDialogue.Length && _index == 0)
            {
                enabledAll(false);
                NextLine();
            }
            else if ((Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0)) && _index < introductionDialogue.Length)
            {
                NextLine();
            }
            else if ((Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0)) && _index == introductionDialogue.Length)
            {
                EndDialogue();
                enabledAll(true);
                _hasTalked = true;
                NPC.transform.position = new Vector3(-13f, 1.3f, -84f);
                NPC.transform.rotation = Quaternion.Euler(0, 0, 0);

                dialogueBoxArrivee.GetComponent<BoxCollider>().enabled = false;
                dialogueBoxChoix.GetComponent<BoxCollider>().enabled = true;
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
    
    void enabledAll(bool enabled)
    {
        player.GetComponent<PlayerMovement>().enabled = enabled;
        camera.GetComponent<HorizontalMouseLook>().enabled = enabled;
        unityChan.GetComponent<PlayerControllerPlanet3>().enabled = enabled;
        unityChan.GetComponent<Animator>().enabled = enabled;
    }
}
