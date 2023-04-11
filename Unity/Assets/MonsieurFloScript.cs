using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsieurFloScript : MonoBehaviour
{
    public Animator myAnimator;
    bool animationLancée = false;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator.speed = 0;
        MonsieurFloDetectorScript.animerFloEvent += lancerAnimation;
    }

    void lancerAnimation()
    {
        
        animationLancée = !animationLancée;
        if (animationLancée)
        {
            myAnimator.speed = 1;
        }
        else
        {
            myAnimator.speed = 0;
        }
    }
}
