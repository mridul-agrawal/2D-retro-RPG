using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavingPlayerStats : MonoBehaviour
{
    public PlayerStats Roy;

    public void AddExp()
    {
        Roy.AddExp(150);
        Debug.Log("Exp Added");
    }

    public void SavePlayerStats()
    {
        string royStatsJSON = JsonUtility.ToJson(Roy);
        File.WriteAllText(Application.dataPath + "/Saves/saveFileRoyStats.json", royStatsJSON);
    }

    public void LoadPlayerStats()
    {
        string json = File.ReadAllText(Application.dataPath + "/Saves/saveFileRoyStats.json");
        JsonUtility.FromJsonOverwrite(json,Roy);
    }

}
