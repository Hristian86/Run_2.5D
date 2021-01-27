using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
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
        CheckForHorizontalMovement();
        CheckForMovementJump();
    }

    private void CheckForMovementJump()
    {
        this.jump = Input.GetAxisRaw("Jump");
        Vector3 updatedVelosity = this.playerBody.velocity;

        if (jump > 0 && this.isGrounded && updatedVelosity.y < 0.1f)
        {
            this.playerBody.AddForce(0, this.jumpSpeed, 0);
            this.playerBody.freezeRotation = true;
            this.isGrounded = false;
        }
    }

    private void CheckForHorizontalMovement()
    {
        float horizontals = Input.GetAxisRaw("Horizontal");

        if (horizontals > 0)
        {
            Debug.Log("here");
            //animator.SetFloat("walk", horizontals);
        }

        if (horizontals != 0 && this.horizontal != horizontals)
        {
            if (horizontals > 0)
            {
                //if (this.horizontal < 0.50f && this.isGrounded)
                //{
                //    this.horizontal += 0.20f;
                //}

                //if (this.isGrounded && horizontals == 0)
                //{
                //    this.horizontal -= 0.10f;
                //}


                if (this.moveLocked)
                {
                    HorizontalForwardCheck(horizontals);
                }

            }
            else if (horizontals < 0)
            {
                //if (this.horizontal > -0.50f && this.isGrounded)
                //{
                //    // Make a variable.
                //    this.horizontal += -0.20f;
                //}

                //if (!this.isGrounded)
                //{
                //    this.horizontal = -0.30f;
                //}


                if (this.moveLocked)
                {
                    HorizontalBackwordCheck(horizontals);
                }
            }
        }
    }

    private void HorizontalBackwordCheck(float horizontals)
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

    private void HorizontalForwardCheck(float horizontals)
    {
        Vector3 updatedVelosity = this.playerBody.velocity;
        if (updatedVelosity.z > this.maxSpeed)
        {
            updatedVelosity.z = this.maxSpeed;
            this.playerBody.velocity = updatedVelosity;
        }
        else
        {
            this.playerBody.AddForce(0, 0, horizontals * this.Speed * Time.deltaTime);
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