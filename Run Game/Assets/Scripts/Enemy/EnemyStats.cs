using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : EnemyHeathStats
{

    [SerializeField] public GameObject playerObject;
    [SerializeField] public float TimerForNextAttack;
    [SerializeField] public float Cooldown;
    [SerializeField] public Transform enemyTransform;
    private string playerTag = "Player";


    private void Start()
    {
        this.InitPlayer();

        this.Cooldown = 3;
        this.TimerForNextAttack = this.Cooldown;
        base.currentHealth = this.maxHealth;
        this.healthBar.SetMaxHealth(base.maxHealth);
        this.healthBar.setHealth(base.maxHealth);

    }

    private void InitPlayer()
    {
        this.playerObject = GameObject.FindGameObjectWithTag(this.playerTag);
        base.player = playerObject.GetComponent<PlayerStats>();
        base.mySelfNpcActions = gameObject.GetComponent<EnemyCOntroller>();
    }

    private void Update()
    {
        this.DoDamageToPlayer();
        this.DisplayHealthAndLevelHud();
    }

    private void DisplayHealthAndLevelHud()
    {
        base.enemyHealthText.text = $"Lv: {base.NPCLevel}";
    }

    private void DoDamageToPlayer()
    {
        if (base.mySelfNpcActions != null && base.mySelfNpcActions.Interact)
        {
            // To do combat
            // it works.
            //Debug.Log("COMBAT");
            if (this.TimerForNextAttack > 0)
            {
                this.TimerForNextAttack -= Time.deltaTime;
            }
            else if (this.TimerForNextAttack <= 0)
            {
                if (!this.isDead && !this.player.isDead)
                {
                    this.SetNPCDamage();
                    this.player.TakeDamage(base.damage.GetValue);
                }

                this.TimerForNextAttack = this.Cooldown;
            }
        }
    }

    private void SetNPCDamage()
    {
        var baseDmg = 20;
        base.damage.SetDamage(baseDmg * base.NPCLevel);
    }

    public override void Die()
    {
        base.isDead = true;
        Destroy(gameObject);
    }
}
