using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    #region "Variables"
    public Rigidbody Rigid;
    private float MouseSensitivity = 1.4f;
    private float MoveSpeed = 0.5f;
    private float JumpForce = 1f;
    private bool rightBUttonClicked;
    #endregion

    private void Start()
    {
        this.rightBUttonClicked = false;
    }

    void Update()
    {
        this.CheckForMouseRotationWithRightButton();

        Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
    }

    private void CheckForMouseRotationWithRightButton()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            this.rightBUttonClicked = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            this.rightBUttonClicked = false;
        }

        if (this.rightBUttonClicked)
        {
            this.PlayerMoveWithMouse();
        }
    }

    private void PlayerMoveWithMouse()
    {
        Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
    }
}
