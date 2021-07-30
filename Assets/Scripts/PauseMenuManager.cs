using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public CanvasRenderer PauseMenuUI;
    public CanvasRenderer[] PlayerStatsPanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) )
        {
            if(!PauseMenuUI.gameObject.activeInHierarchy)
            {
                PauseMenuUI.gameObject.SetActive(true);
                UpdateUIStats();
                PlayerManager.instance.MenuOpen = true;
            } else
            {
                PauseMenuUI.gameObject.SetActive(false);
                PlayerManager.instance.MenuOpen = false;
            }
            PlayerManager.instance.CanPlayerMove();
        }
    }

    public void UpdateUIStats()
    {
        for(int i=0; i<PlayerStatsManager.PSManagerInstance.ListOfPlayerStats.Count; i++)
        {
            PlayerStatsPanel[i].gameObject.SetActive(PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].inPlayerPool);

            if(PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].inPlayerPool)
            {
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().characterSprite.sprite
                = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].mugshot;
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().NameText.text
                    = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].name;
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().LevelText.text
                    = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].currentLevel.ToString();
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().HealthText.text
                    = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].health.ToString();
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().ManaText.text
                    = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].mana.ToString();
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().ExpText.text
                    = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].currentExp.ToString();
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().StrengthText.text
                    = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].strength.ToString();
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().DefenceText.text
                    = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].defense.ToString();
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().MagicText.text
                    = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].magic.ToString();
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().ResistanceText.text
                    = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].resistance.ToString();
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().expSlider.value
                    = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].currentExp;
                PlayerStatsPanel[i].GetComponent<CharStatsUIManager>().expSlider.maxValue
                    = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].expProgression[PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[i].currentLevel];
            }

        }
    }

}
