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

        // Increase player max experience need to level up...
        this.SolveExperiencePerLevelIncrease();

        base.isDead = false;
        this.resetEnemies = false;
        this.healthBar.SetMaxHealth(base.maxHealth);
        this.healthBar.SetHealth(base.maxHealth);
        this.InitEnemies();

        // For leveling
        base.currentHealth = base.maxHealth;
    }

    private void Update()
    {
        base.UpdateSystems();
    }
}
