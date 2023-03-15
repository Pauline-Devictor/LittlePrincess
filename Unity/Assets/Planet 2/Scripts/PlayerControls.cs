using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    private float inputX;
    private float inputY;

	private Vector2 vector2;

	public UnityEvent<Vector2> onInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // Get keyboard inputs
    {
        inputY = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");
		vector2 = new Vector2(inputX, inputY).normalized;
		onInput.Invoke(vector2);
        // Debug.Log(inputX + "," + inputY);
    }	
}
