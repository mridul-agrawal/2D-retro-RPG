using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public List<PlayerStats> ListOfPlayerStats;
    public static PlayerStatsManager PSManagerInstance;

    void Start()
    {
        if (PSManagerInstance == null)
        {
            PSManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void AddExpForAll()
    {
        foreach (PlayerStats ps in ListOfPlayerStats)
        {
            ps.AddExp();
        }
    }

    public void SaveAllPS()
    {
        foreach(PlayerStats ps in ListOfPlayerStats)
        {
            ps.SavePlayerStats();
        }
    }

    public void LoadAllPS()
    {
        foreach (PlayerStats ps in ListOfPlayerStats)
        {
            ps.LoadPlayerStats();
        }
    }

    public void LoadAllBasePS()
    {
        foreach (PlayerStats ps in ListOfPlayerStats)
        {
            ps.LoadBasePlayerStats();
        }
    }

}
