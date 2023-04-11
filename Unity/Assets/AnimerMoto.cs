using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimerMoto : MonoBehaviour
{
    public delegate void animerMoto();
    public static event animerMoto animerMotoEvent;

    
    private void OnTriggerEnter(Collider other)
    {
        animerMotoEvent?.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        animerMotoEvent?.Invoke();
    }
    
    
}
