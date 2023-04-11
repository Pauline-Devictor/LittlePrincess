using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovements : MonoBehaviour
{ 
    public float moveSpeed;
    public float maxSpeed;

    public Transform orientation;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _moveDirection;
    public Rigidbody rb;

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;


    private void Start()
    {
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
        ApplyGravity();

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
       // _horizontalInput = Input.GetAxis("Horizontal");
       _horizontalInput = Input.GetAxisRaw("Horizontal");
       Debug.Log("_horizontalInput" + _horizontalInput);
        //_verticalInput = Input.GetAxis("Vertical");
        _verticalInput = Input.GetAxisRaw("Vertical");
        Debug.Log("_verticalInput" + _verticalInput);
    }

    private void MovePlayer()
    {
        if (_verticalInput > 0 )
        {
            _moveDirection = (orientation.forward * _verticalInput) + (orientation.right * _horizontalInput);

            if (_verticalInput != 0)
            {
                rb.AddForce(_moveDirection.normalized * moveSpeed, ForceMode.Force);
            }

            rb.velocity = _moveDirection;

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void ApplyGravity()
    {
        _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        _moveDirection.y = _velocity;
    }
}