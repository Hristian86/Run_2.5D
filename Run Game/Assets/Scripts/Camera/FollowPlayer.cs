﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 offsetCamera;

    private void Start()
    {
        var obj = GameObject.FindWithTag("Player").GetComponent<PlayerContorller>();

        player = obj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CameraFolow();
    }

    private void CameraFolow()
    {
        offsetCamera.x = 1.7f;
        offsetCamera.y = 1f;
        offsetCamera.z = 10.5f;
        Vector3 playerPos = player.position - offsetCamera;
        playerPos.z = playerPos.z + 4f;
        playerPos.y = playerPos.y + 3.5f;
        transform.position = playerPos;

        // To do move player direction to mouseX...

    }
}
