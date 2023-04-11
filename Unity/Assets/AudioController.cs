using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    private int _index;

    void playAudio()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
