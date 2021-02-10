using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatMethods : SaveManager
{
    protected void InitEnemies()
    {
        var allEn = GameObject.FindGameObjectsWithTag("Enemy")
            .Where(x => !x.GetComponent<EnemyStats>().isDead)
            .Select(a => a).ToList();
        base.allEnemies = allEn;

        base.visitedEnemy = new bool[allEn.Count];
        Debug.Log(visitedEnemy.Length);
    }


    protected void AssignEnemy(GameObject enemy)
    {
        base.enemyObject = enemy;
        base.enemyPosition = enemyObject.transform;
        base.enemy = enemyObject.GetComponent<EnemyCOntroller>();
        base.enemyStats = enemyObject.GetComponent<EnemyStats>();
        base.selectionManager.SetEnemyByPressingTab(enemy.transform);
    }

    protected void SwitchTargetWithTab()
    {
        // Make event every 2 minutes to check for respowned enemies.
        if (base.resetEnemies)
        {
            // Refresh enemy list...
            this.InitEnemies();
        }

        //Debug.Log(this.allEnemies.Length);
        if (base.allEnemies.Count > 0)
        {
            // Loop through enemies and select...
            this.AssignEnemyWithLoop();
        }
    }

    protected void AssignEnemyWithLoop()
    {
        if (base.allEnemies.Count > 0)
        {
            for (int i = 0; i < this.allEnemies.Count; i++)
            {
                if (!base.visitedEnemy.Contains(false))
                {
                    base.visitedEnemy = new bool[base.allEnemies.Count];
                }

                if (!base.visitedEnemy[i])
                {
                    this.AssignEnemy(this.allEnemies[i]);
                    base.visitedEnemy[i] = true;
                    return;
                }
            }
        }
    }

    // Attacking enemy...
    protected void AttackEnemy()
    {
        if (enemy != null)
        {
            if (!base.isDead && !base.enemyStats.isDead)
            {
                // Enemy takes damage...
                this.enemyStats.TakeDamage(this.CalculatedamageDone());

                if (base.enemyStats.isDead)
                {
                    this.DeadEnemyAndAddExperience();
                }
            }
        }
    }

    private void DeadEnemyAndAddExperience()
    {
        if (enemyObject != null)
        {
            base.allEnemies.Remove(enemyObject); // Remove enemy from the list to target...
        }

        this.InitEnemies();

        // Add experience to the variable...
        base.AddExperience();
    }

    private int CalculatedamageDone()
    {
        var damageDone = CalculateDMG();
        return damageDone;
    }

    private int CalculateDMG()
    {
        var dmg = base.baseDamage * this.playerLevel;
        base.damage.SetDamage(dmg);

        return base.damage.GetValue;
    }

    public void SetEnemy(Transform enemyPosition)
    {
        base.enemyPosition = enemyPosition;
        base.enemy = enemyPosition.GetComponent<EnemyCOntroller>();
        base.enemyStats = enemyPosition.GetComponent<EnemyStats>();
    }
}
