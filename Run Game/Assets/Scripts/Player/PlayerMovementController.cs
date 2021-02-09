using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    #region "Variables"
    public Rigidbody Rigid;
    private float MouseSensitivity = 0.1f;
    private float MoveSpeed = 0.5f;
    private float JumpForce = 1f;
    #endregion

    void Update()
    {
        //Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));

        Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
    }
}
