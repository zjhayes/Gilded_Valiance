using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;

    public Image fadeOverlay;
    public float fadeSpeed;
    
    public bool shouldFadeToBlack;
    public bool shouldFadeFromBlack;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(shouldFadeToBlack)
        {
            fadeOverlay.color = new Color(fadeOverlay.color.r, 
                fadeOverlay.color.g, fadeOverlay.color.b, 
                Mathf.MoveTowards(fadeOverlay.color.a, 1f, fadeSpeed * Time.deltaTime));

            if(fadeOverlay.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if(shouldFadeFromBlack)
        {
            fadeOverlay.color = new Color(fadeOverlay.color.r, 
                fadeOverlay.color.g, fadeOverlay.color.b, 
                Mathf.MoveTowards(fadeOverlay.color.a, 0, fadeSpeed * Time.deltaTime));

            if(fadeOverlay.color.a == 0)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
