using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialLoader : MonoBehaviour
{
    public Canvas UICanvas;
    public GameObject Player;

    private void Awake()
    {
        if(UIFade.UIinstance == null)
        {
            Instantiate(UICanvas);
        }
        if(PlayerManager.instance == null)
        {
            Instantiate(Player);
        }
    }

}
