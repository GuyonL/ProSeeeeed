using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    //Variables
    public float speed = 5f;
    public float jumpHeight = 2f;
    private float groundDistance = 0.5f;
    public LayerMask Ground;
    private Rigidbody monkeyBody;
    private Vector3 inputs = Vector3.zero;
    private bool isGrounded = true;
    private Transform groundChecker;

    void Start()
    {
        monkeyBody = GetComponent<Rigidbody>();
        groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, Ground, QueryTriggerInteraction.Ignore);

        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        if (inputs != Vector3.zero)
            transform.forward = inputs;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            monkeyBody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        
    }


    void FixedUpdate()
    {
        monkeyBody.MovePosition(monkeyBody.position + inputs * speed * Time.fixedDeltaTime);
    }
}
