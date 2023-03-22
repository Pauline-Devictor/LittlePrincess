using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTurn : MonoBehaviour
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
    void Awake()
    {
        var rotation = Quaternion.Euler(
            Time.time * xSpeed,
            Time.time * ySpeed,
            Time.time * zSpeed
        );
        transform.rotation = rotation;
    }

    void Start()
    {
        var rotation = Quaternion.Euler(
            Time.time * xSpeed,
            Time.time * ySpeed,
            Time.time * zSpeed
        );
        transform.rotation = rotation;
    }
}
