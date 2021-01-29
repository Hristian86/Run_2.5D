using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetController : MonoBehaviour
{
    private Rigidbody playerBody;
    private Rigidbody petBody;
    private float step = 200f;

    private void Awake()
    {
        var obj = GameObject.FindGameObjectWithTag("Player");
        this.playerBody = obj.GetComponent<Rigidbody>();

        var obj1 = GameObject.FindGameObjectWithTag("Pet");
        this.petBody = obj1.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    private void Follow()
    {

        Transform target = this.playerBody.transform;
        //target.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);
        //target.transform.position = new Vector3(0.8f, 0.0f, 0.8f);

        Transform transform = this.petBody.transform;

        transform.position = Vector3.MoveTowards(target.position, transform.position, step * Time.deltaTime);

        // Check if the position of the player and pet are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the player.
            target.position *= -1.0f;
        }
    }
}
