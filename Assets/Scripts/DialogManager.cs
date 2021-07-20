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
    public bool justFinished;

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
                    Debug.Log("Inside if");
                    DialogueText.text = DialogueLines[currentLine];
                } else
                {
                    Debug.Log("Inside else");
                    DialogueBox.SetActive(false);
                    justFinished = true;
                    PlayerManager.instance.canMove = true;
                }

                currentLine++;

            }
        }
    }

    public void ShowDialogue(string[] lines)
    {
        Debug.Log("Inside ShowDialogue");
        DialogueLines = lines;
        currentLine = 0;
        DialogueText.text = DialogueLines[currentLine];
        DialogueBox.SetActive(true);
        currentLine++;
        PlayerManager.instance.canMove = false;
    }

}
