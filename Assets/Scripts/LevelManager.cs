using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager 
{
    public int[] expProgression;
    public int[][] statsProgression;

    private int currentExp = 0;
    private int currentLevel = 0;
    private int maxLevel = 9;

    public LevelManager()
    {

    }


    public void AddExp(int expToAdd, out int currentExp, out int currentLevel)
    {
        if(this.currentLevel == maxLevel)
        {
            currentExp = 0;
            currentLevel = 9;
            return;
        }

        currentExp = this.currentExp;
        currentLevel = this.currentLevel;

        currentExp += expToAdd;

        if(currentExp >= expProgression[currentLevel])
        {
            currentExp -= expProgression[currentLevel];
            currentLevel++;
        }

        this.currentExp = currentExp;
        this.currentLevel = currentLevel;
        
    }


}
