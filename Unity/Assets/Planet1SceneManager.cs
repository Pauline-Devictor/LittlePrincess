using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet1SceneManager : MonoBehaviour
{

    public GameObject outside;

    public GameObject inside;

    // Start is called before the first frame update
    void Start()
    {
        TriggerOutdoorToIndoor.enterMuseum += enterMuseum ;
        TriggerIndoorToOutdoor.exitMuseum += exitMuseum;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void enterMuseum()
    {
        outside.SetActive(false);
        inside.SetActive(true);
    }
    
    void exitMuseum()
    {
        outside.SetActive(true);
        inside.SetActive(false);
    }
}
