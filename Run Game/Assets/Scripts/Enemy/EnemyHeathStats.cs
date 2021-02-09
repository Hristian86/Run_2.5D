using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeathStats : MonoBehaviour
{
    public int maxHealth = 300;

    protected EnemyCOntroller mySelfNpcActions;
    protected PlayerStats player;

    public int currentHealth { get; private set; }

    [SerializeField] public BaseStats damage;
    [SerializeField] public BaseStats armor;
    public bool isDead { get; private set; }

    private void Start()
    {
        this.isDead = false;
    }

    private void Awake()
    {
        this.currentHealth = this.maxHealth;
    }

    public void TakeDamage(int damage)
    {
        
        if (!this.isDead)
        {
            // make npc chase you when you hit it with range damage.
            this.mySelfNpcActions.chasePl = true;

            damage -= this.armor.GetValue;
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            this.currentHealth -= damage;

            Debug.Log(transform.name + "Takes damage" + damage + "damage");
        }

        if (this.currentHealth <= 0)
        {
            this.isDead = true;
            this.Die();
        }
    }

    public virtual void Die()
    {
        //Debug.Log(transform.name + "died.");
    }
}
