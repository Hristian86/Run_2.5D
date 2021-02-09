using System;
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
    private Transform selectionToClear;
    private PlayerStats setPlayer;
    private EnemyStats enemyStatsForCheck;

    public Camera camera;
    private Transform currentTarget;

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

    private void SelectEn(Transform selection)
    {
        // Selecting enemy.
        var enController = selection.GetComponent<EnemyCOntroller>();
        var enStats = selection.GetComponent<EnemyStats>();

        this.ChangePreviosColloer(selection);

        if (enStats != null)
        {
            this.enemyStatsForCheck = enStats;
            var sel = selection.GetComponent<Renderer>();
            sel.material = this.markedEnemyMatirial;

            this.setPlayer.SetEnemy(enController, enStats);
        }
        else
        {
            this.setPlayer.SetEnemy(null, null);
        }
    }

    private void ChangePreviosColloer(Transform selection)
    {
        if (this.currentTarget != null)
        {
            var sel = currentTarget.GetComponent<Renderer>();
            sel.material = this.defaultMatirial;
        }

        this.currentTarget = selection;
    }
}
