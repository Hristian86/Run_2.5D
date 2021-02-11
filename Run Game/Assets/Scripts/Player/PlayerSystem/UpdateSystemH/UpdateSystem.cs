using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateSystem : CombatMethods
{

    protected void UpdateSystems()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            base.SwitchTargetWithTab();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            base.AttackEnemy();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            base.WriteToSave();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Patch for now...
            SceneManager.LoadScene("MainMenu");
        }

        base.healthBar.SetHealth(base.currentHealth);
        this.ShowHud();
    }

    private void ShowHud()
    {
        this.ShowLevelAndExperience();
        this.ShowPlayerName();
        this.ShowHealthNumbers();
    }

    private void ShowHealthNumbers()
    {
        base.playerHealthNumbers.text = $"{base.currentHealth}/{base.maxHealth}";
    }

    private void ShowPlayerName()
    {
        base.playerName.text = $"{this.transform.name}";
    }

    protected void ShowLevelAndExperience()
    {
        base.playerExperienceAndLevel.text = $"Lv.{this.playerLevel} " +
            $"Exp: {base.experience}/{base.maxExPerLevel}";
    }
}
