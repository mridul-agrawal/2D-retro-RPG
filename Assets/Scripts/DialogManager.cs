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

    void Start()
    {
        DialogueText.text = DialogueLines[currentLine] + " \n\t";
    }

    void Update()
    {
        if(DialogueBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                currentLine++;

                if (currentLine < DialogueLines.Length)
                {
                    DialogueText.text = DialogueLines[currentLine] + " \n\t";
                } else
                {
                    DialogueBox.SetActive(false);
                }

            }
        }


        
    }
}
