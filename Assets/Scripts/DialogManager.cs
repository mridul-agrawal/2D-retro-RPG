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
        if(DM_Instance == null)
        {
            DM_Instance = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if(DialogueBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (currentLine < DialogueLines.Length)
                {
                    CheckIfName();
                    DialogueText.text = DialogueLines[currentLine];
                } else
                {
                    DialogueBox.SetActive(false);
                    justFinished = true;
                    PlayerManager.instance.canMove = true;
                }

                currentLine++;

            }
        }
    }

    public void ShowDialogue(string[] lines, bool isPerson)
    {
        DialogueLines = lines;
        currentLine = 0;
        CheckIfName();
        DialogueText.text = DialogueLines[currentLine];
        DialogueBox.SetActive(true);
        SpeakerBox.SetActive(isPerson);
        currentLine++;
        PlayerManager.instance.canMove = false;
    }

    public void CheckIfName()
    {
        if(DialogueLines[currentLine].StartsWith("n-"))
        {
            SpeakerText.text = DialogueLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }

}
