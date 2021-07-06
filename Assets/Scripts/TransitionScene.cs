using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    public string SceneToLoad;

    private void Start()
    {
        if(PlayerManager.instance.LastAreaTransitionUsed != "Start" && PlayerManager.instance.LastAreaTransitionUsed == this.name)
        {
            PlayerManager.instance.transform.position = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.instance.LastAreaTransitionUsed = this.name;

            SceneManager.LoadScene(SceneToLoad);

        }
    }

}
