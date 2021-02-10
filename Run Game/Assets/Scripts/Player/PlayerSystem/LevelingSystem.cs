using System;
using UnityEngine;

public class LevelingSystem : CharacterStats
{
    protected float calculateLevelHealth = 0.2f;
    protected float bonusHealthPerTenLevel = 1.3f;
    protected int baseLevelExperience = 20;
    protected int baseHalth = 700;
    protected int playerLevel;
    protected long experience = 300;
    protected int maxExPerLevel = 2000;
    protected int baseDamage = 20;
    protected int increasedDamagePerLevels = 5;
    protected int bonusLevels = 10;

    /// <summary>
    /// Add Experience per monster slain...
    /// </summary>
    protected void AddExperience()
    {
        this.experience += this.baseLevelExperience * this.playerLevel;

        this.CheckForLevelUp();
    }

    // Per level calculation...
    protected void calculateHealtPerLevelInit(int level)
    {
        this.playerLevel = level;
        this.CalculateHealthInit();
    }

    // Adding bonus health and calculate it...
    private void CalculateHealthInit()
    {
        if (this.playerLevel % this.bonusLevels != 0)
        {
            this.maxHealth = (int)(this.baseHalth + ((this.baseHalth * this.calculateLevelHealth) * this.playerLevel));
        }
        else
        {
            this.maxHealth = (int)((this.baseHalth + ((this.baseHalth * this.calculateLevelHealth) * this.playerLevel)) * bonusHealthPerTenLevel);
        }
    }

    protected void CheckForLevelUp()
    {
        if (this.experience > this.maxExPerLevel && this.experience != 0)
        {
            this.playerLevel += 1;
            this.experience = Math.Abs(this.experience - this.maxExPerLevel);

            // Increase damage per 5 levels...
            if (this.playerLevel % this.increasedDamagePerLevels == 0)
            {
                CalculateIncreasedDamage();
            }

            // Can be made when leveled to fill the missing health...
            // Increse play health when leveled up...
            this.CalculateHealthInit();
        }
    }

    private void CalculateIncreasedDamage()
    {
        this.baseDamage *= 2;
    }
}
