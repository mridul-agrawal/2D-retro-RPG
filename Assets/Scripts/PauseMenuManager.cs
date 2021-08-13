using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public CanvasRenderer PauseMenuUI;
    public CharStatsUIManager[] PlayerStatsPanel;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) )
        {
            if(!PauseMenuUI.gameObject.activeInHierarchy)
            {
                PauseMenuUI.gameObject.SetActive(true);
                UpdateAllUIStats(true);
                PlayerManager.instance.MenuOpen = true;
            } else
            {
                PauseMenuUI.gameObject.SetActive(false);
                PlayerManager.instance.MenuOpen = false;
            }
            PlayerManager.instance.CanPlayerMove();
        }
    }

    public void UpdateAllUIStats(bool initialized)
    {
        foreach (CharStatsUIManager cs in PlayerStatsPanel)
        {
            if (cs.gameObject.activeSelf)
            {
                cs.UpdateStats(initialized);
            }
        }
    }

}
