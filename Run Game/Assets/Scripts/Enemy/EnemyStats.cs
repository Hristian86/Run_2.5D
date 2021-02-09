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
        this.playerObject = GameObject.FindGameObjectWithTag(this.playerTag);
        base.player = playerObject.GetComponent<PlayerStats>();
        base.mySelfNpcActions = gameObject.GetComponent<EnemyCOntroller>();

        Cooldown = 3;
        TimerForNextAttack = Cooldown;
    }

    private void Update()
    {
        if (base.mySelfNpcActions != null && base.mySelfNpcActions.Interact)
        {
            // To do combat
            // it works.
            //Debug.Log("COMBAT");
            if (TimerForNextAttack > 0)
            {
                TimerForNextAttack -= Time.deltaTime;
            }
            else if (TimerForNextAttack <= 0)
            {
                if (!this.isDead && !this.player.isDead)
                {
                    this.player.TakeDamage(base.damage.GetValue);
                }

                TimerForNextAttack = Cooldown;
            }
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
