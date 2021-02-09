using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerContorller movement;
    [SerializeField] private GameObject playerObject;

    private void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        movement = playerObject.GetComponent<PlayerContorller>();
    }

    public void OnCollisionEnter(Collision collisionInfo)
    {
        // On colide to see what object is collided.
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
        }
    }
}
