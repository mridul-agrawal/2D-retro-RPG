using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    public string[] Lines;

    public bool canActive;


    void Start()
    {
        RectifyLines();
    }

    void Update()
    {
        if(canActive && Input.GetButtonUp("Fire1") && !DialogManager.DM_Instance.DialogueBox.activeInHierarchy)
        {
            // Dont Open Dialogue Box if it has just been closed in the same frame by DialogManager.
            if(DialogManager.DM_Instance.justFinished)
            {
                DialogManager.DM_Instance.justFinished = false;
                return;
            }

            DialogManager.DM_Instance.ShowDialogue(Lines);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canActive = false;
        }
    }

    public void RectifyLines()
    {
        for(int i=0; i<Lines.Length; i++)
        {
            if (Lines[i].StartsWith("1-"))
            {
                Lines[i] = Lines[i] + " \n\t ";
                Lines[i] = Lines[i].Replace("1-", "");
            }
        }
    }

}
