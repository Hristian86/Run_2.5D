using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    public Camera camera;
    private Rigidbody playerBody;

    private float Speed = 600f;
    private float maxSpeed = 15f;

    private float jumpSpeed = 450f;
    private float jump = 0f;

    private bool isDead;
    private bool gameStarted;

    private float horizontal = 0f;
    private bool moveLocked = false;
    private bool isGrounded = true;
    private float position;

    private float ultimateSpeed;
    //private Animator animator;

    private void Awake()
    {
        var obj = GameObject.FindGameObjectWithTag("Player");
        this.playerBody = obj.GetComponent<Rigidbody>();

        this.ultimateSpeed = this.horizontal * this.Speed * Time.deltaTime;

        //animator = GetComponent<Animator>();

        this.moveLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForVerticalMovement();
        CheckForHorizontalMovement();
        CheckFOrRotation();
        CheckForMovementJump();
    }

    private void CheckFOrRotation()
    {
        // To do mouse move and mov ement.
        this.position = Input.GetAxisRaw("Mouse X");
        //this.playerBody.transform.Rotate(0f, position, 0f);
        
    }

    private void CheckForHorizontalMovement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        Vector3 updatedVelosity = this.playerBody.velocity;

        if (updatedVelosity.x < -this.maxSpeed)
        {
            updatedVelosity.x = -this.maxSpeed;
            this.playerBody.velocity = updatedVelosity;
        }
        else if (updatedVelosity.x > this.maxSpeed)
        {
            updatedVelosity.x = this.maxSpeed;
            this.playerBody.velocity = updatedVelosity;
        }
        else
        {
            this.playerBody.AddForce(horizontalMove * this.Speed * Time.deltaTime, 0, 0);
        }
    }

    private void CheckForMovementJump()
    {
        this.jump = Input.GetAxisRaw("Jump");
        Vector3 updatedVelosity = this.playerBody.velocity;

        if (jump > 0 && this.isGrounded && updatedVelosity.y < 0.1f)
        {
            this.playerBody.AddForce(0, this.jumpSpeed, 0);
            this.isGrounded = false;
        }
    }

    private void CheckForVerticalMovement()
    {
        float verticalMove = Input.GetAxisRaw("Vertical");
        
        if (verticalMove != 0 && this.horizontal != verticalMove)
        {
            if (verticalMove > 0)
            {
                if (this.moveLocked)
                {
                    verticalForwardCheck(verticalMove);
                }

            }
            else if (verticalMove < 0)
            {
                if (this.moveLocked)
                {
                    verticalBackwordCheck(verticalMove);
                }
            }
        }
    }

    private void verticalBackwordCheck(float horizontals)
    {

        Vector3 updatedVelosity = this.playerBody.velocity;

        if (updatedVelosity.z < -this.maxSpeed)
        {
            updatedVelosity.z = -this.maxSpeed;
            this.playerBody.velocity = updatedVelosity;
        }
        else
        {
            this.playerBody.AddForce(0, 0, horizontals * this.Speed * Time.deltaTime);
        }
    }

    private void verticalForwardCheck(float horizontals)
    {
        //Vector3 updatedVelosity = this.playerBody.velocity;
        //if (updatedVelosity.z > this.maxSpeed)
        //{
        //    updatedVelosity.z = this.maxSpeed;
        //    this.playerBody.velocity = updatedVelosity;
        //}
        //else
        //{
        //    this.playerBody.AddForce(0, 0, horizontals * this.Speed * Time.deltaTime);
        //}

        if (position > 0)
        {
            playerBody.position += playerBody.transform.forward * Time.deltaTime * position;
        }
        else if(position < 0)
        {
            playerBody.position -= playerBody.transform.forward * Time.deltaTime * position;
        }
        else
        {
            playerBody.position += playerBody.transform.forward * Time.deltaTime * 5;
        }
    }

    public void OnCollisionEnter(Collision collisionInfo)
    {
        // On colide to see what object is collided.
        if (collisionInfo.collider.tag == "Ground")
        {
            this.isGrounded = true;
            this.moveLocked = true;
        }
    }
}