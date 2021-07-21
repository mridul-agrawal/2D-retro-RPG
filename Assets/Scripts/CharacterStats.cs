using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int mana;
    public int maxMana;
    public int currentExp;
    public int level;

    public int strength;
    public int defense;
    public int magic;
    public int resistance;
    public int weaponStrength;
    public int armourStrength;
    public string weaponEquipped;
    public string armourEquipped;

    public int[] expProgression;
    public int[][] statsProgression;

    private LevelManager levelManager;

    public int expToAdd;


    private void Awake()
    {
        levelManager = new LevelManager();
        levelManager.expProgression = expProgression;
        levelManager.statsProgression = statsProgression;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            levelManager.AddExp(expToAdd, out currentExp, out level);
        }
    }



}
