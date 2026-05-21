using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    
    public float forwardSpeed = 0;
    public float sidewaysSpeed = 0;
    public float rotationSpeed = 0;
    public Vector2 moveVector;
    
    //Speed caps
    public float FORWARDSPEEDCAP;
    public float SIDESPEEDCAP;
    public float ROTATIONSPEEDCAP;

    //Change per frame
    public float fSpeedPerFrame;
    public float sSpeedPerFrame;
    public float rSpeedPerFrame;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        forwardSpeed = 0;
        sidewaysSpeed = 0;
        rotationSpeed = 0;
        moveVector = Vector2.zero;
    
        //Speed caps
        FORWARDSPEEDCAP = 300f;
        SIDESPEEDCAP = 300f;
        ROTATIONSPEEDCAP = 300f;

        //Change per frame
        fSpeedPerFrame = 1.0f;
        sSpeedPerFrame = 0.8f;
        rSpeedPerFrame = 1.3f;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.Q)) {
        //     rotationSpeed += rSpeedPerFrame;
        // }
        // if (Input.GetKey(KeyCode.E)) {
        //     rotationSpeed += -rSpeedPerFrame;
        // }
        //
        // if (Input.GetKey(KeyCode.W)) {
        //     forwardSpeed += fSpeedPerFrame;
        // }
        // if (Input.GetKey(KeyCode.S)) {
        //     forwardSpeed += -fSpeedPerFrame;
        // }
        //
        // if (Input.GetKey(KeyCode.A)) {
        //     sidewaysSpeed += -sSpeedPerFrame;
        // }
        // if (Input.GetKey(KeyCode.D)) {
        //     sidewaysSpeed += sSpeedPerFrame;
        // }

        forwardSpeed = moveVector.y * 30;
        sidewaysSpeed = moveVector.x * 30;
        
        FixVariables();
        Move();
        ApplyFriction();
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        float moveX = context.ReadValue<Vector2>().x;
        float moveY = context.ReadValue<Vector2>().y;
        
        Debug.Log("x" + moveX + " " + "y" + moveY);
        
        moveVector = new Vector2(moveX, moveY);
        
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        Debug.Log("test");
        float turnInput = context.ReadValue<float>();
        Debug.Log($"turnInput{turnInput}");
        //ISSUE: triggers are not being detected (method not printing)
    }

    private void FixedUpdate()
    {
        
    }

    void FixVariables()
    {
        if (Mathf.Abs(rotationSpeed) < 0.01) {
            rotationSpeed = 0;
        }
        if (Mathf.Abs(forwardSpeed) < 0.01) {
            forwardSpeed = 0;
        }
        if (Mathf.Abs(sidewaysSpeed) < 0.01) {
            sidewaysSpeed = 0;
        }
        
        //Rot
        if (rotationSpeed > ROTATIONSPEEDCAP) {
            rotationSpeed = ROTATIONSPEEDCAP;
        }
        if (rotationSpeed < -ROTATIONSPEEDCAP) {
            rotationSpeed = -ROTATIONSPEEDCAP;
        }
        
        //F-B
        if (forwardSpeed > FORWARDSPEEDCAP) {
            forwardSpeed = FORWARDSPEEDCAP;
        }
        if (forwardSpeed < -FORWARDSPEEDCAP) {
            forwardSpeed = -FORWARDSPEEDCAP;
        }
        
        //L-R
        if (sidewaysSpeed > SIDESPEEDCAP) {
            sidewaysSpeed = SIDESPEEDCAP;
        }
        if (sidewaysSpeed < -SIDESPEEDCAP) {
            sidewaysSpeed = -SIDESPEEDCAP;
        }
        
    }

    void Move()
    {
        // transform.Rotate(0,0,rotationSpeed);
        // transform.position += transform.up * (forwardSpeed * Time.deltaTime);
        // transform.position += transform.right * (sidewaysSpeed * Time.deltaTime);
        
        rigidBody.rotation += rotationSpeed * 1 * Time.deltaTime;
        rigidBody.AddForce(transform.up * (forwardSpeed * 80 * Time.deltaTime));
        rigidBody.AddForce(transform.right * (sidewaysSpeed * 80 * Time.deltaTime));
    }

    void ApplyFriction()
    {
        rotationSpeed *= 0.99f;
        forwardSpeed *= 0.98f;
        sidewaysSpeed *= 0.98f;
    }
    
    
    
}