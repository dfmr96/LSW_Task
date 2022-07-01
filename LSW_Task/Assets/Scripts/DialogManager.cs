using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] bool dialogActive;

    public string[] dialogLines;
    public int currentDialogLine;
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space)) //If dialog is active and playyer push a key, next dialog line
        {
            currentDialogLine++;
        }

        if (currentDialogLine >= dialogLines.Length) //if dialog dont have more lines, hide dialogBox. Reset lines
        {
            HideDialog();
        }
        else
        {
            dialogText.text = dialogLines[currentDialogLine]; //Change dialog text in placeholder text

        }
    }

    public void ShowDialog(string[] lines) //Show dialog method with dialog lines as array
    {
        dialogActive = true;
        dialogBox.SetActive(true);
        currentDialogLine = 0;
        dialogLines = lines;
        //playerController.playerTalking = true; //TODO Player talking to avoid movement while talking
    }

    public void HideDialog()
    {
        dialogActive = false;
        dialogBox.SetActive(false);
        currentDialogLine = 0;
        //playerController.playerTalking = false; //TODO Player talking to avoid movement while talking
    }
}


