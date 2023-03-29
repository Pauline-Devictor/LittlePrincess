using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIndoorToOutdoor : MonoBehaviour
{
    public BoxCollider triggerObject;
    public delegate void ExitMuseum();
    public static event ExitMuseum exitMuseum;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerObject.bounds.Contains(transform.position))
        {

           exitMuseum?.Invoke();
           
           gameObject.transform.position = new Vector3(0, 0, 0);

        }
        else
        {
            Debug.Log("Not Triggered");
        }
    }
    
}
