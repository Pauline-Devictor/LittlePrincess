using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOutdoorToIndoor : MonoBehaviour
{
    public BoxCollider triggerObject;
    public delegate void EnterMuseum();
    public static event EnterMuseum enterMuseum;

    // Update is called once per frame
    void Update()
    {
        if (triggerObject.bounds.Contains(transform.position))
        {
           
           enterMuseum?.Invoke();
           
           gameObject.transform.localPosition = new Vector3(0, 0, 0);
           gameObject.transform.Rotate(0, 180, 0);

        }
        else
        {
            Debug.Log("Not Triggered");
        }
    }
    
}
