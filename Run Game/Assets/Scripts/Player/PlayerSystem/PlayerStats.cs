using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : UpdateSystem
{
    private void Start()
    {
        // Initialize the health and level + experience...
        base.ReadSave();
        //base.calculateHealtPerLevelInit(base.currentLevel);

        base.isDead = false;
        this.resetEnemies = false;
        this.healthBar.SetMaxHealth(base.maxHealth);
        this.healthBar.SetHealth(base.maxHealth);
        this.InitEnemies();

        // For leveling
        base.currentHealth = base.maxHealth;
    }

    //private void Awake()
    //{
    //    base.currentHealth = base.maxHealth;
    //}

    private void Update()
    {
        base.UpdateSystems();
    }
}
