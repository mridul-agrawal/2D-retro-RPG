using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public CanvasRenderer PauseMenuUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) )
        {
            if(!PauseMenuUI.gameObject.activeInHierarchy)
            {
                PauseMenuUI.gameObject.SetActive(true);
            } else
            {
                PauseMenuUI.gameObject.SetActive(false);
            }
        }

    }
}
