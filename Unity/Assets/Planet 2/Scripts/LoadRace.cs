using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadRace : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(7);
        }
    }
}
