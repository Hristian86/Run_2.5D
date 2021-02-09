using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] public Rigidbody _rigitBody;

        private float _movementForse = 10f;
        private float maxSpeed = 100f;

        private float _jumpForce = 300f;
        private bool _shouldJump;

        private bool isGrounded = true;

        private void Start()
        {
            var obj = GameObject.FindGameObjectWithTag("Player");
            this._rigitBody = obj.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            SpeedCheck();
            ShouldJump();
        }

        private void ShouldJump()
        {
            if (this._shouldJump == false && this.isGrounded)
            {
                this.isGrounded = false;
                this._shouldJump = Input.GetKeyDown(KeyCode.Space);
            }
        }

        private void SpeedCheck()
        {
            Vector3 updatedVelosity = this._rigitBody.velocity;

            if (updatedVelosity.z > -this.maxSpeed && updatedVelosity.z < this.maxSpeed)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    this._rigitBody.AddForce(_movementForse * Vector3.forward);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    this._rigitBody.AddForce(_movementForse * -Vector3.forward);
                }
            }
        }

        private void FixedUpdate()
        {
            Vector3 updatedVelosity = this._rigitBody.velocity;
            Debug.Log(updatedVelosity.y);
            if (this._shouldJump && updatedVelosity.y < 0.10f && !this.isGrounded)
            {
                this._rigitBody.AddForce(this._jumpForce * Vector3.up);
                this._shouldJump = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Ground")
            {
                this.isGrounded = true;
            }
        }
    }
}
