using System.Collections;
using System.Collections.Generic;

using UnityEngine.Events; // needed to use UnityEvent
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public UnityEvent<CarIdentity, Checkpoint> onCheckpointEnter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider collider)
    {
        // if entering object is tagged as the Player
        if (collider.GetComponent<CarIdentity>() != null)
        {
            // fire an event giving the entering gameObject and this checkpoint
            onCheckpointEnter.Invoke(collider.gameObject.GetComponent<CarIdentity>(), this);
        }
    }
}
