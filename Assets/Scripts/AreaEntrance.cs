using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName; // Set by AreaExit

    void Start()
    {
        if(transitionName == PlayerController.instance.lastTransition)
        {
            PlayerController.instance.transform.position = transform.position;
        }

        UIFade.instance.FadeFromBlack();
    }

    void Update()
    {
        
    }
}
