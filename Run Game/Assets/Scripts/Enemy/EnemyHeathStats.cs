using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHeathStats : MonoBehaviour
{

    public int maxHealth = 300;
    // Get this npc level to calculate the experience...
    public int NPCLevel = 1;

    protected EnemyCOntroller mySelfNpcActions;
    protected PlayerStats player;

    public Text enemyHealthText;
    public Text damageTakenText;

    [SerializeField] public NPC_Health_Bar healthBar;

    protected int currentHealth { get; set; }

    [SerializeField] public BaseStats damage;
    [SerializeField] public BaseStats armor;
    public bool isDead { get; protected set; }

    public void TakeDamage(int damage)
    {
        
        if (!this.isDead)
        {
            // make npc chase you when you hit it with range damage.
            this.mySelfNpcActions.chasePl = true;

            damage -= this.armor.GetValue;
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            this.currentHealth -= damage;
            this.healthBar.setHealth(this.currentHealth);

            this.takaDamageDisplay(damage);

            Debug.Log(transform.name + "Takes damage" + damage + "damage");
        }

        if (this.currentHealth <= 0)
        {
            this.isDead = true;
            this.Die();
        }
    }

    private void takaDamageDisplay(int damage)
    {
        this.damageTakenText.text = $"{damage}";
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

    public virtual void Die()
    {
        //Debug.Log(transform.name + "died.");
    }
}
