using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class SaveManager : LevelingSystem
{

    protected void WriteToSave()
    {
        using (StreamWriter write = new StreamWriter(@"E:\SaveGame.txt"))
        {
            string y = "level:1";
            if (base.playerLevel > 0)
            {
                y = $"level:{this.playerLevel}";
            }
            string x = $"exp:{this.experience}";
            write.WriteLine(y);
            write.WriteLine(x);
        }
    }

    protected void ReadSave()
    {
        using (StreamReader read = new StreamReader(@"E:\SaveGame.txt"))
        {
            string SavedLevel = read.ReadLine();
            Debug.Log(SavedLevel);
            string level = SavedLevel.Split(':')[1];

            //string level = this.RegExSaveData(SavedLevel);
            Debug.Log(level);
            var curLevel = 0;
            var bo = int.TryParse(level, out curLevel);
            if (bo)
            {
                this.playerLevel = int.Parse(level);
            }

            string SaveXp = read.ReadLine();
            Debug.Log(SaveXp);
            string exp = SaveXp.Split(':')[1];
            //string exp = this.RegExSaveData(SaveXp);
            Debug.Log(exp);

            long curExp = 0;
            var ex = long.TryParse(exp, out curExp);
            if (ex)
            {
                this.experience = curExp;
            }


            this.ApplaySaveData();
        }
    }

    private void ApplaySaveData()
    {
        this.calculateHealtPerLevelInit(this.playerLevel);
        this.healthBar.SetMaxHealth(base.maxHealth);
        base.currentHealth = base.maxHealth;
        this.healthBar.SetHealth(this.currentHealth);
    }

    protected virtual string RegExSaveData(string data)
    {
        var pattern = @"<\w+>";
        var y = Regex.Match(data, pattern).ToString();
        return y.Trim();
    }
}
