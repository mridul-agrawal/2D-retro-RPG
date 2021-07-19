using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    public string[] Lines;

    public bool canActive;


    void Start()
    {
        
    }

    void Update()
    {
        if(canActive && Input.GetButtonDown("Fire1") && !DialogManager.DM_Instance.DialogueBox.activeInHierarchy)
        {
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

}
