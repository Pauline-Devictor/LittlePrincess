using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadMenu()
    {
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
    public void LoadMenuPlanet()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(5);
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