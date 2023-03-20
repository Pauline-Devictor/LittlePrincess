using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public Button resumeButton;
    public Button quitButton;

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
        quitButton.onClick.AddListener(GoBackToMenu);
    }

    void ResumeGame()
    {
        _isMenuActive = false;
        menuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}