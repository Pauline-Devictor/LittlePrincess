using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;
    // move the cylinder with thkeys W, Q, S, D
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * (Time.deltaTime * speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * (Time.deltaTime * speed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * (Time.deltaTime * speed));
        }
    }
}