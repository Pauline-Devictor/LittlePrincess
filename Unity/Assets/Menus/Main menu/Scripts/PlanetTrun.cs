using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTrun : MonoBehaviour
{
    private static  float defaultValue = 50f;
    public float xSpeed = defaultValue;
    public float ySpeed = defaultValue;
    public float zSpeed = defaultValue;
    void Update()
    {
        var rotation = Quaternion.Euler(
            Time.time * xSpeed,
            Time.time * ySpeed,
            Time.time * zSpeed
        );
        transform.rotation = rotation;
    }
}
