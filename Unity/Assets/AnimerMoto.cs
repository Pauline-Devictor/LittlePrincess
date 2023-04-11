using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimerMoto : MonoBehaviour
{
    public delegate void animerMoto();
    public static event animerMoto animerMotoEvent;
    
    bool isInteractable = false;

    public void Update()
    {
        if (isInteractable)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animerMotoEvent?.Invoke();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        isInteractable = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        isInteractable = false;
    }
}
