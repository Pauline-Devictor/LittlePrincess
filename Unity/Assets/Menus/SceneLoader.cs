using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadMenu()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
    public void PlayPlanet1()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayPlanet2()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayPlanet3()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(4);
    }

    public void Quit()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}