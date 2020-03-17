﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;

    public int currentLine;

    private bool justStarted;

    void Start()
    {  
        instance = this;
    }

    void Update()
    {
        if(dialogBox.activeInHierarchy)
        {
            if(Input.GetButtonUp("Fire1"))
            {
                if(!justStarted)
                {
                    currentLine++;

                    if(currentLine < dialogLines.Length)
                    {
                        CheckIfName();
                        dialogText.text = dialogLines[currentLine];
                    }
                    else
                    {
                        dialogBox.SetActive(false);
                        PlayerController.instance.canMove = true;
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
        }
    }

    public void ShowDialog(string[] newLines)
    {
        ClearDialogBox();

        dialogLines = newLines;

        currentLine = 0;

        CheckIfName();

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);

        justStarted = true;

        PlayerController.instance.canMove = false;
    }

    public void CheckIfName()
    {
        if(dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
            nameBox.SetActive(true);
        }
    }

    public void ClearDialogBox()
    {
        nameBox.SetActive(false);
        dialogText.text = null;
        nameText.text = null;
    }
}
