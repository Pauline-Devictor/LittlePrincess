using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCourse : MonoBehaviour
{
    public PlayerControls playerControls;
    public AIControls[] aiControls;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;
    public AudioSource audioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;
    void Awake()
    {
        StartGame();
    }
    public void StartGame()
    {
        FreezePlayers(true);
        StartCoroutine("Countdown");
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);

        tricolorLights.SetProgress(1);
        audioSource.PlayOneShot(lowBeep);
        yield return new WaitForSeconds(1);

        tricolorLights.SetProgress(2);
        audioSource.PlayOneShot(lowBeep);
        yield return new WaitForSeconds(1);
        
        tricolorLights.SetProgress(3);
        audioSource.PlayOneShot(lowBeep);
        yield return new WaitForSeconds(1);
        
        tricolorLights.SetProgress(4);
        audioSource.PlayOneShot(highBeep);
        StartRacing();
        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
    }
    public void StartRacing()
    {
        FreezePlayers(false);
    }
    void FreezePlayers(bool freeze)
    {
        // log the current state
        //Debug.Log("FreezePlayers: " + freeze);
        
        //TODO : freeze players here
        playerControls.enabled = !freeze;
        foreach (AIControls ai in aiControls)
        {
            ai.enabled = !freeze;
        }
    }
}