using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public Button resumeButton;

    private bool _isMenuActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isMenuActive = !_isMenuActive;

            if (_isMenuActive)
            {
                menuPanel.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                menuPanel.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
    }

    void ResumeGame()
    {
        _isMenuActive = false;
        menuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}