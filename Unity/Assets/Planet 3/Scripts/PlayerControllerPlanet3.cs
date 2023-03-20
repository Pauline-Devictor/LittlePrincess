using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPlanet3 : MonoBehaviour
{
    public Animator anim;
    

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
    }
}
