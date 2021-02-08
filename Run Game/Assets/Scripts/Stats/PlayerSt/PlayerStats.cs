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

    private void Start()
    {
        base.isDead = false;
    }

    private void Awake()
    {
        this.InitEnemy();
        base.currentHealth = base.maxHealth;
    }

    private void InitEnemy()
    {
        var allEn = GameObject.FindGameObjectsWithTag("Enemy")
            .Where(x => x.GetComponent<EnemyCOntroller>().Interact == true)
            .Select(a => a).ToArray();

        if (allEn.Length > 0)
        {
            foreach (var enemies in allEn)
            {
                if (enemies.GetComponent<EnemyCOntroller>().Interact)
                {
                    this.enemyObject = enemies;

                    this.enemy = enemyObject.GetComponent<EnemyCOntroller>();
                    this.enemyStats = enemyObject.GetComponent<EnemyStats>();
                }
            }
        }
    }

    private void Update()
    {
        this.InitEnemy();
        if (enemy != null && enemy.Interact)
        {

            if (!base.isDead && !this.enemyStats.isDead)
            {
                this.enemyStats.TakeDamage(base.damage.GetValue);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
        }
    }

}
