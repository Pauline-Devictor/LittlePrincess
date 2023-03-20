using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
   //     Vector3 desiredPosition = target.position + offset;
     //   Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,smoothSpeed);
       // transform.position = smoothedPosition;
        transform.position = target.position + offset;
      
      transform.LookAt(target);
    }
    
    
}
