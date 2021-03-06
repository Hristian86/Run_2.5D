﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCOntroller : MonoBehaviour
{
    public float loockRadius = 10f;
    public string player = "Player";
    public bool chasePl;

    public bool Interact { get; set; }

    private Transform target;
    NavMeshAgent agent;

    private void Awake()
    {
        var obj = GameObject.FindGameObjectWithTag(this.player);
        this.target = obj.GetComponent<Rigidbody>().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        this.chasePl = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.ChasePlayer();
    }

    public void ChasePlayer()
    {
        float distance = Vector3.Distance(this.target.position, this.transform.position);

        if (distance <= this.loockRadius || this.chasePl)
        {
            this.agent.SetDestination(this.target.position);

            if (distance <= agent.stoppingDistance)
            {
                this.FaceTarget();
                this.Interact = true;
                // Attack
            }
            else
            {
                this.Interact = false;
            }
        }
        else
        {
            // TO DO Return to start position...
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (this.target.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, this.loockRadius);
    }

}
