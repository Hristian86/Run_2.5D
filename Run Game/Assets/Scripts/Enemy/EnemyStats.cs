using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : EnemyHeathStats
{
    public GameObject playerObject;

    private void Start()
    {
        base.player = playerObject.GetComponent<PlayerStats>();
        base.mySelfNpcActions = gameObject.GetComponent<EnemyCOntroller>();
    }

    private void Update()
    {
        if (base.mySelfNpcActions != null && base.mySelfNpcActions.Interact)
        {
            // To do combat
            // it works.
            //Debug.Log("COMBAT");

            if (!this.isDead && !this.player.isDead)
            {
                this.player.TakeDamage(base.damage.GetValue);
            }
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
