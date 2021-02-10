using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected EnemyCOntroller enemy;
    [SerializeField] protected GameObject enemyObject;
    [SerializeField] protected EnemyStats enemyStats;
    [SerializeField] public HeathBarScript healthBar;
    [SerializeField] public SelectionManager selectionManager;
    [SerializeField] protected List<GameObject> allEnemies;
    [SerializeField] protected Transform enemyPosition;

    protected bool[] visitedEnemy;
    protected string player = "Player";
    protected bool resetEnemies; // not used yet.

    // TO DO...
    protected int maxHealth;
    protected int currentHealth;

    // For items from monsters.
    [SerializeField] public BaseStats damage;
    [SerializeField] public BaseStats armor;

    public bool isDead { get; set; }

    public void TakeDamage(int damage)
    {
        if (!this.isDead)
        {
            damage -= this.armor.GetValue;
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            this.currentHealth -= damage;

            //Debug.Log(transform.name + "Takes damage" + damage + "damage");
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
