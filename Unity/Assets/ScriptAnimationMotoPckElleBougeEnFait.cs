using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimationMotoPckElleBougeEnFait : MonoBehaviour
{
    // Start is called before the first frame update
    public bool animationLancée = false;
    void Start()
    {
     AnimerMoto.animerMotoEvent += lancerAnimation;   
    }
    
    private void Update()
    {
        if (animationLancée)
        {
            // go up go down sinusoide motion 
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time)/50, transform.position.z);
        }
    }

    // Update is called once per frame
    private void lancerAnimation()
    {
     animationLancée = !animationLancée; 
    }
}
