using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    public string SceneToLoad;
    private float waitToLoadNextScene = 1f;
    private bool loadNextScene;

    private void Start()
    {
        waitToLoadNextScene = 1f;
        if (PlayerManager.instance.LastAreaTransitionUsed != "Start" && PlayerManager.instance.LastAreaTransitionUsed == this.name)
        {
            PlayerManager.instance.transform.position = transform.position;
        }
        UIFade.UIinstance.FadeToWhite();
    }

    private void Update()
    {
        if(loadNextScene)
        {
            waitToLoadNextScene -= Time.deltaTime;
        }
        if(waitToLoadNextScene <= 0)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.instance.LastAreaTransitionUsed = this.name;
            UIFade.UIinstance.FadeToBlack();
            loadNextScene = true;
        }
    }

}
