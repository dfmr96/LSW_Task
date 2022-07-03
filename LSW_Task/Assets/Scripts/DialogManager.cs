using TMPro;
using UnityEngine;


public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;
    public bool dialogActive; //??

    public string[] dialogLines;
    public int currentDialogLine;
    public PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {

        if (playerController.playerTalking)
        {
            dialogText.text = dialogLines[currentDialogLine]; //Change dialog text in placeholder 
        }

    }

    public void ShowDialog(string[] lines) //Show dialog method with dialog lines as array
    {

        playerController.playerTalking = true;
        dialogBox.SetActive(true);
        dialogActive = true;
        dialogLines = lines;

        //TODO Player talking to avoid movement while talking
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
        dialogActive = false;
        playerController.playerTalking = false;
        UnityEngine.Debug.Log("Player talking = false, Hide Dialog");
        //TODO Player talking to avoid movement while talking
    }
}


