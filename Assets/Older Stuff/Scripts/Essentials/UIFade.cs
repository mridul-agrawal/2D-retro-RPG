using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{

    public static UIFade UIinstance;
    public Image fadeImage;
    public float fadeSpeed = 3f;

    public bool shouldFadeToBlack;
    public bool shouldFadeToWhite;

    void Start()
    {
        if(UIinstance == null)
        {
            UIinstance = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if(shouldFadeToBlack)
        {
            if(fadeImage.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.MoveTowards(fadeImage.color.a, 1f, fadeSpeed * Time.deltaTime));
        }
        if(shouldFadeToWhite)
        {
            if (fadeImage.color.a == 0f)
            {
                shouldFadeToWhite = false;
            }
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.MoveTowards(fadeImage.color.a, 0f, fadeSpeed * Time.deltaTime));
        }

    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeToWhite = false;
    }

    public void FadeToWhite()
    {
        shouldFadeToWhite = true;
        shouldFadeToBlack = false;
    }

}
