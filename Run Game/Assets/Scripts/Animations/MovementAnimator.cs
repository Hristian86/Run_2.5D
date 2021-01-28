using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimator : MonoBehaviour
{
    private Animator animator;
    private Transform transform;

    private void Start()
    {
        animator = GetComponent<Animator>();

        //transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("walk", Input.GetAxisRaw("Vertical"));
        SetJump();
    }

    private void SetJump()
    {
        if (Input.GetAxisRaw("Jump") != 0)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }
}
