using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        base.healthBar.SetHealth(base.currentHealth);
    }
}
