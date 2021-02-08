using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : EnemyHeathStats
{
    private EnemyCOntroller mySelf;
    public GameObject playerObject;
    public PlayerStats player;

    private void Start()
    {
        player = playerObject.GetComponent<PlayerStats>();
        mySelf = gameObject.GetComponent<EnemyCOntroller>();
    }

    private void Update()
    {
        if (mySelf != null && this.mySelf.Interact)
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
