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
            if(ps.inPlayerPool)
            {
                ps.AddExp();
            }
        }
        CallUpdateUIStats(false);
    }

    public void SaveAllPS()
    {
        foreach(PlayerStats ps in ListOfPlayerStats)
        {
            if(ps.inPlayerPool)
            {
                ps.SavePlayerStats();
            }
        }
        CallUpdateUIStats(true);
    }

    public void LoadAllPS()
    {
        foreach (PlayerStats ps in ListOfPlayerStats)
        {
            if (ps.inPlayerPool)
            {
                ps.LoadPlayerStats();
            }
        }
        CallUpdateUIStats(true);
    }

    public void LoadAllBasePS()
    {
        foreach (PlayerStats ps in ListOfPlayerStats)
        {
            if(ps.inPlayerPool)
            {
                ps.LoadBasePlayerStats();
            }
        }
        CallUpdateUIStats(true);
    }

    public void CallUpdateUIStats(bool initialized)
    {
        UIFade.UIinstance.gameObject.GetComponent<PauseMenuManager>().UpdateAllUIStats(initialized);
    }

}
