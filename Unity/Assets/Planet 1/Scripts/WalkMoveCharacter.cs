using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    
    void Update()
    {
        // look into the direction of the input
        var movement = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            z = Input.GetAxisRaw("Vertical")
        };

        rb.MovePosition(rb.position + movement * (speed * Time.deltaTime));
        if (!movement.Equals(Vector3.zero))
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}
