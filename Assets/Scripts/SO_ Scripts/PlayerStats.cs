using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/CharacterStats")]
public class PlayerStats : ScriptableObject
{
    public int health;
    public int maxHealth;
    public int mana;
    public int maxMana;
    public int currentExp;
    public int currentLevel;
    public int maxLevel;

    public int strength;
    public int defense;
    public int magic;
    public int resistance;
    public int weaponStrength;
    public int armourStrength;

    public string weaponEquipped;
    public string armourEquipped;

    public int[] expProgression;
    public int[] maxHealthProgression;
    public int[] maxManaProgression;
    public int[] strengthProgression;
    public int[] defenseProgression;
    public int[] magicProgression;
    public int[] resistanceProgression;


    public void AddExp()
    {
        AddExp(150);
    }

    public void AddExp(int expToAdd)
    {
        if (currentLevel == maxLevel)
        {
            currentExp = 0;
            currentLevel = 9;
            return;
        }

        currentExp += expToAdd;
        if (currentExp >= expProgression[currentLevel])
        {
            currentExp -= expProgression[currentLevel];
            LevelUp();
        }
    }

    public void LevelUp()
    {
        currentLevel++;
        maxHealth += maxHealthProgression[currentLevel];
        maxMana += maxManaProgression[currentLevel];
        strength += strengthProgression[currentLevel];
        defense += defenseProgression[currentLevel];
        magic += magicProgression[currentLevel];
        resistance += resistanceProgression[currentLevel];
    }

    public void SavePlayerStats()
    {
        string royStatsJSON = JsonUtility.ToJson(this);
        File.WriteAllText(Application.dataPath + "/Saves/saveFile" + this.name + "Stats.json", royStatsJSON);
    }

    public void LoadPlayerStats()
    {
        string json = File.ReadAllText(Application.dataPath + "/Saves/saveFile" + this.name + "Stats.json");
        JsonUtility.FromJsonOverwrite(json, this);
    }

    public void LoadBasePlayerStats()
    {
        string json = File.ReadAllText(Application.dataPath + "/Saves/saveBase" + this.name + "Stats.json");
        JsonUtility.FromJsonOverwrite(json, this);
    }

}
