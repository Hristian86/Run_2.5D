﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private string[] selectableTags = new string[] { "Enemy", "Pet" };
    private RaycastHit hit;
    [SerializeField] public Material highlightMatirial;
    [SerializeField] public Material defaultMatirial;
    [SerializeField] public Material markedEnemyMatirial;
    [SerializeField] private Transform selectionToClear;
    [SerializeField] private PlayerStats setPlayer;
    [SerializeField] private EnemyStats enemyStatsForCheck;

    public Camera camera;
    [SerializeField] private Transform currentTarget;

    private void Start()
    {
        this.setPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        this.SelectTarget();
    }

    private void SelectTarget()
    {
        if (this.selectionToClear != null)
        {
            var selectionRenderer = this.selectionToClear.GetComponent<Renderer>();
            var checkingEnemies = selectionRenderer.GetComponent<EnemyStats>();

            if ((selectionRenderer != null && this.enemyStatsForCheck != checkingEnemies) || checkingEnemies == null)
            {
                selectionRenderer.material = this.defaultMatirial;
            }

            this.selectionToClear = null;
        }

        var ray = this.camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            var selection = this.hit.transform;

            if (this.selectableTags.Any(x => selection.CompareTag(x)))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();

                this.SelectEnemyWithMouseClick(selection);

                if (selectionRenderer != null)
                {
                    selectionRenderer.material = this.highlightMatirial;
                }

                this.selectionToClear = selection;
            }
        }
    }

    private void SelectEnemyWithMouseClick(Transform selection)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            this.SelectEn(selection);
        }
    }

    public void SetEnemyByPressingTab(Transform selection)
    {
        this.SelectEn(selection);
    }

    private void SelectEn(Transform selection)
    {
        // Selecting enemy.
        var enStats = selection.GetComponent<EnemyStats>();

        this.ChangePreviosColor(selection);

        if (enStats != null)
        {
            this.enemyStatsForCheck = enStats;
            var sel = selection.GetComponent<Renderer>();
            sel.material = this.markedEnemyMatirial;

            this.setPlayer.SetEnemy(selection);
        }
        else
        {
            this.setPlayer.SetEnemy(null);
        }
    }

    // Change the color of the previos target to defaul one.
    private void ChangePreviosColor(Transform selection)
    {
        if (this.currentTarget != null)
        {
            var sel = currentTarget.GetComponent<Renderer>();
            sel.material = this.defaultMatirial;
        }

        this.currentTarget = selection;
    }
}
