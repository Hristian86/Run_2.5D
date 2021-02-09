using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private EnemyCOntroller enemy;
    private GameObject enemyObject;
    private EnemyStats enemyStats;

    public HeathBarScript healthbar;

    private void Start()
    {
        base.isDead = false;
        this.healthbar.SetMaxHealth(base.maxHealth);
        this.healthbar.SetHealth(base.maxHealth);
    }

    private void Awake()
    {
        //this.InitEnemies();
        base.currentHealth = base.maxHealth;
    }

    private void InitEnemies()
    {
        var allEn = GameObject.FindGameObjectsWithTag("Enemy")
            .Where(x => x.GetComponent<EnemyCOntroller>().Interact == true)
            .Select(a => a).ToArray();

        if (allEn.Length > 0)
        {
            foreach (var enemies in allEn)
            {
                this.enemyObject = enemies;
                this.enemy = enemyObject.GetComponent<EnemyCOntroller>();
                this.enemyStats = enemyObject.GetComponent<EnemyStats>();
            }
        }
    }

    private void Update()
    {
        this.InitEnemies();

        if (Input.GetKeyDown(KeyCode.F))
        {
            this.AttackEnemy();
        }

        this.healthbar.SetHealth(base.currentHealth);
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
