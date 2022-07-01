using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] string[] dialog;
    private DialogManager manager;
    private bool playerInTheZone;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTheZone && Input.GetKeyDown(KeyCode.Return)) //If player is inside Dialog Trigger and press button, show Dialog
        {
            manager.ShowDialog(dialog); //Dialog lines in inspector will be shown
            
            /*
            if (gameObject.GetComponentInParent<NPCMovement>() != null)
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
            }
            */
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //PLayer can trigger dialog
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInTheZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Player exit trigger zone
        {
            playerInTheZone = false;
            manager.HideDialog();
        }
    }
}
