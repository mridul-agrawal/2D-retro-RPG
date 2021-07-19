using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI SpeakerText;
    public GameObject DialogueBox;
    public GameObject SpeakerBox;

    public string[] DialogueLines;
    public int currentLine;

    public static DialogManager DM_Instance;

    void Start()
    {
        DM_Instance = this;
    }

    void Update()
    {
        if(DialogueBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (currentLine < DialogueLines.Length)
                {
                    DialogueText.text = DialogueLines[currentLine] + " \n\t";
                } else
                {
                    DialogueBox.SetActive(false);
                }

                currentLine++;

            }
        }
    }

    public void ShowDialogue(string[] lines)
    {
        DialogueLines = lines;
        currentLine = 0;
        DialogueText.text = DialogueLines[currentLine];
        DialogueBox.SetActive(true);

    }

}
