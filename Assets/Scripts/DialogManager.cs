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

    }

    void Update()
    {
        if(currentLine >= 0 && currentLine < DialogueLines.Length)
        {
            DialogueText.text = DialogueLines[currentLine];
        }
    }
}
