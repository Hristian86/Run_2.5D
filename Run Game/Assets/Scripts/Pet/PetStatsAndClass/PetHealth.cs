using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetHealth : MonoBehaviour
{
    protected int maxHealth;
    protected int currenthealth;

    protected int baseHalth = 500;
    protected int NPCLevel;
    protected float calculateLevelHealth = 0.2f;
    protected float bonusHealthPerTenLevel = 1.3f;
    protected long experience;

    protected void SetExperience(long ex)
    {
        this.experience += ex;
    }

    protected void calculateHealtPerLevelInit(int level)
    {
        this.NPCLevel = level;

        if (level % 10 != 0)
        {
            this.maxHealth = (int)(this.baseHalth + ((this.baseHalth * this.calculateLevelHealth) * this.NPCLevel));
        }
        else
        {
            this.maxHealth = (int)((this.baseHalth + ((this.baseHalth * this.calculateLevelHealth) * this.NPCLevel)) * bonusHealthPerTenLevel);
        }
    }
}
