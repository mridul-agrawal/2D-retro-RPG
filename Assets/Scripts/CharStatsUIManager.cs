using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharStatsUIManager : MonoBehaviour
{
    public int playerNO;
    public Image characterSprite;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ManaText;
    public TextMeshProUGUI ExpText;
    public TextMeshProUGUI StrengthText;
    public TextMeshProUGUI DefenceText;
    public TextMeshProUGUI MagicText;
    public TextMeshProUGUI ResistanceText;
    public Slider expSlider;

    public PlayerStats thisPlayerSO;

    public void Start()
    {
        SetPlayerSOReference();
        SetPanelActive();
    }

    public void SetPanelActive()
    {
        gameObject.SetActive(thisPlayerSO.inPlayerPool);
    }

    public void SetPlayerSOReference()
    {
        thisPlayerSO = PlayerStatsManager.PSManagerInstance.ListOfPlayerStats[playerNO];
    }

    public void UpdateStats(bool initialized)
    {
        SetPlayerSOReference();

        characterSprite.sprite = thisPlayerSO.mugshot;
        characterSprite.preserveAspect = true;
        NameText.text = thisPlayerSO.name;
        LevelText.text = "LVL: " + (thisPlayerSO.currentLevel+1).ToString();
        HealthText.text = "Health: " + thisPlayerSO.health.ToString() + "/" + thisPlayerSO.maxHealth.ToString();
        ManaText.text = "Mana: " + thisPlayerSO.mana.ToString() + "/" + thisPlayerSO.maxMana.ToString();
        ExpText.text = "Exp: " + thisPlayerSO.currentExp.ToString() + "/" + thisPlayerSO.expProgression[thisPlayerSO.currentLevel].ToString();
        StrengthText.text = "Str: " + thisPlayerSO.strength.ToString();
        DefenceText.text = "Def: " + thisPlayerSO.defense.ToString();
        MagicText.text = "Mag: " + thisPlayerSO.magic.ToString();
        ResistanceText.text = "Res: " + thisPlayerSO.resistance.ToString();
        expSlider.maxValue = thisPlayerSO.expProgression[thisPlayerSO.currentLevel];

        if(initialized)
        {
            expSlider.value = thisPlayerSO.currentExp;
        } else
        {
            StartCoroutine(AnimateSliderOverTime(1));
        }

        
        //expSlider.value = thisPlayerSO.currentExp;
    }

    IEnumerator AnimateSliderOverTime(float seconds)
    {
        float animationTime = 0f;
        float currentSliderValue = expSlider.value; 

        if(currentSliderValue <= thisPlayerSO.currentExp)
        {
            while (animationTime < seconds)
            {
                animationTime += Time.deltaTime;
                float lerpValue = animationTime / seconds;
                expSlider.value = Mathf.Lerp(currentSliderValue, thisPlayerSO.currentExp, lerpValue);
                yield return null;
            }
        } else
        {
            while (animationTime < seconds)
            {
                animationTime += Time.deltaTime;
                float lerpValue = animationTime / seconds;
                expSlider.value = Mathf.Lerp(currentSliderValue, thisPlayerSO.expProgression[thisPlayerSO.currentLevel], lerpValue);
                yield return null;
            }

            expSlider.value = 0;

            while (animationTime < seconds)
            {
                animationTime += Time.deltaTime;
                float lerpValue = animationTime / seconds;
                expSlider.value = Mathf.Lerp(currentSliderValue, thisPlayerSO.currentExp, lerpValue);
                yield return null;
            }

        }

        
    }

}
