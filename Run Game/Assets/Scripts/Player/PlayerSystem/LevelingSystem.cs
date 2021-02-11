using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelingSystem : CharacterStats
{
    protected float calculateLevelHealth = 0.2f;
    protected float bonusHealthPerTenLevel = 1.3f;
    protected int baseLevelExperience = 510;
    protected int baseHalth = 700;
    protected int playerLevel; // Default value...
    protected long experience; // Default value...
    protected int maxExPerLevel = 2000;
    protected int baseDamage = 20;
    protected int increasedDamagePerLevels = 5;
    protected int bonusLevels = 10;
    private float expIncreasePerLeveValue = 1.5f;
    private int multiplyPerLevelExperience = 100;

    [SerializeField] public Text playerExperienceAndLevel;
    [SerializeField] public Text playerName;
    [SerializeField] public Text playerHealthNumbers;


    /// <summary>
    /// Add Experience per monster slain...
    /// </summary>
    protected void AddExperience(int nPCLevel)
    {
        int difference = Math.Abs(playerLevel - nPCLevel);
        if (playerLevel > nPCLevel)
        {
            difference += 1;
            this.experience += ((this.baseLevelExperience - Math.Abs(this.baseLevelExperience / difference)) + this.calculateBonusExp());
        }
        else if (playerLevel < nPCLevel)
        {
            difference += 1;
            this.experience += ((this.baseLevelExperience + (this.baseLevelExperience * difference)) + this.calculateBonusExp());
        }
        else
        {
            this.experience += (this.baseLevelExperience + this.calculateBonusExp());
        }

        this.CheckForLevelUp();
    }

    private int calculateBonusExp()
    {
        return this.playerLevel * this.multiplyPerLevelExperience;
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
            // Increase maxExperrience per leve...
            this.IncreaseMaxExpPerLevel();
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

    /// <summary>
    /// Icrease max experience based on player level...
    /// </summary>
    protected void SolveExperiencePerLevelIncrease()
    {
        for (int i = 1; i < this.playerLevel; i++)
        {
            this.IncreaseMaxExpPerLevel();
        }
    }

    // Increase experience per level...
    protected void IncreaseMaxExpPerLevel()
    {

        // Calculate multiply for experience...
        //this.expIncreasePerLeveValue *= this.playerLevel;

        this.maxExPerLevel = (int)(this.maxExPerLevel * this.expIncreasePerLeveValue);

    }

    /// <summary>
    /// Increase player damage per level...
    /// </summary>
    private void CalculateIncreasedDamage()
    {
        this.baseDamage *= 2;
    }
}
