using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovements : MonoBehaviour
{ 
    public float moveSpeed;

   public Transform orientation;

   private float _horizontalInput;
   private float _verticalInput;

   private Vector3 _moveDirection;
   public Rigidbody rb;


   private void Start()
   {
       rb.freezeRotation = true;
   }

   private void Update()
   {
       MyInput();
   }

   private void FixedUpdate()
   {
       MovePlayer();
   }

   private void MyInput()
   {
       _horizontalInput = Input.GetAxis("Horizontal");
       _verticalInput = Input.GetAxis("Vertical");
   }

   private void MovePlayer()
   {
       //calculate movement direction
       _moveDirection = (orientation.forward * _verticalInput) + (orientation.right * _horizontalInput);
       
       rb.AddForce(_moveDirection.normalized * moveSpeed, ForceMode.Force);
   }
}