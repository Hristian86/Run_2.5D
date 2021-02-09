using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    [SerializeField] private EnemyCOntroller enemy;
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] public HeathBarScript healthbar;
    [SerializeField] public SelectionManager selectionManager;
    private string player = "Player";
    private GameObject[] allEnemies;
    private bool[] visitedEnemy;

    private void Start()
    {
        base.isDead = false;
        this.healthbar.SetMaxHealth(base.maxHealth);
        this.healthbar.SetHealth(base.maxHealth);
        this.InitEnemies();
    }

    private void Awake()
    {
        //this.InitEnemies();
        base.currentHealth = base.maxHealth;
        this.InitEnemies();
    }

    private void InitEnemies()
    {
        var allEn = GameObject.FindGameObjectsWithTag("Enemy")
            .Select(a => a).ToArray();
        this.allEnemies = allEn;

        this.visitedEnemy = new bool[allEn.Length];
        Debug.Log(visitedEnemy.Length);
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            this.SwitchTarget();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            this.AttackEnemy();
        }

        this.healthbar.SetHealth(base.currentHealth);
    }

    private void SwitchTarget()
    {
        if (this.allEnemies.Length > 1)
        {
            for (int i = 0; i < this.allEnemies.Length; i++)
            {
                if (!this.visitedEnemy.Contains(false))
                {
                    this.visitedEnemy = new bool[this.allEnemies.Length];
                }

                if (!this.visitedEnemy[i])
                {
                    this.enemyObject = this.allEnemies[i];
                    this.enemy = enemyObject.GetComponent<EnemyCOntroller>();
                    this.enemyStats = enemyObject.GetComponent<EnemyStats>();
                    this.visitedEnemy[i] = true;
                    this.selectionManager.SetEnemyByPressingTab(this.allEnemies[i].transform);
                    return;
                }
            }
        }
    }

    private void AttackEnemy()
    {
        if (enemy != null)
        {
            if (!base.isDead && !this.enemyStats.isDead)
            {
                this.enemyStats.TakeDamage(base.damage.GetValue);
            }
        }
    }

    public void SetEnemy(EnemyCOntroller enemyController, EnemyStats enemyStats)
    {
        this.enemy = enemyController;
        this.enemyStats = enemyStats;
    }

}
