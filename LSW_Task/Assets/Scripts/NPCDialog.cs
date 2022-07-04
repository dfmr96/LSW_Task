using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] string[] dialog;
    [SerializeField] DialogManager manager;
    PlayerController playerController;
    private bool playerInTheZone;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform dialogCanvas;
    GameObject buyButtonGO, sellButtonGO;
    [SerializeField] float ButtonOffsetX = 50f, ButtonOffsetY = 50f;
    public GameObject buyScreen,sellScreen;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.playerTalking)
        {

            if (playerInTheZone && Input.GetKeyDown(KeyCode.F)) //If player is inside Dialog Trigger and press button, show Dialog
            {
                {
                    manager.ShowDialog(dialog);//Dialog lines in inspector will be shown
                    ShowTradeButtons();
                    // Debug.Log("Dialogo Activado");
                }
                /*
                if (gameObject.GetComponentInParent<NPCMovement>() != null)
                {
                    gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
                }
                */
            }
        }
        if (playerController.playerTalking && Input.GetKeyDown(KeyCode.Escape))
        {
            manager.HideDialog();
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
    public void ShowTradeButtons()
    {
        var canvasRect = dialogCanvas.GetComponent<RectTransform>().rect;
        
        buyButtonGO = Instantiate(buttonPrefab, dialogCanvas, true);
        buyButtonGO.GetComponentInChildren<TMP_Text>().text = "Buy";
        buyButtonGO.transform.localPosition = new Vector2(canvasRect.xMax - ButtonOffsetX, canvasRect.yMax - ButtonOffsetY);


        EventTrigger triggerBuybutton = buyButtonGO.GetComponent<EventTrigger>();
        EventTrigger.Entry entryBuyButton = new()
        {
            eventID = EventTriggerType.Submit
        };
        entryBuyButton.callback.AddListener((functionIWant) => { BuyButtonTaskOnClick(); });
        EventSystem.current.SetSelectedGameObject(buyButtonGO);
        triggerBuybutton.triggers.Add(entryBuyButton);

        sellButtonGO = Instantiate(buttonPrefab, dialogCanvas, true);
        sellButtonGO.GetComponentInChildren<TMP_Text>().text = "Sell";
        sellButtonGO.transform.localPosition = new Vector2(canvasRect.xMax - ButtonOffsetX, canvasRect.yMin + ButtonOffsetY);

        EventTrigger triggerSellbutton = sellButtonGO.GetComponent<EventTrigger>();
        EventTrigger.Entry entrySellButton = new()
        {
            eventID = EventTriggerType.Submit
        };
        entrySellButton.callback.AddListener((functionIWant) => { SellButtonTaskOnClick(); });
        triggerSellbutton.triggers.Add(entrySellButton);
    }



    public void BuyButtonTaskOnClick()
    {
        buyScreen.SetActive(true);
        if (buyScreen.GetComponent<BuyItemsScroll>().objectsCreated == false)
        {
            buyScreen.GetComponent<BuyItemsScroll>().CreateContent();
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(buyScreen.GetComponent<BuyItemsScroll>().firstChild);

        }
        manager.HideDialog();
        playerController.playerTalking = true;
        DestroyButtons();

    }

    public void SellButtonTaskOnClick()
    {
        sellScreen.SetActive(true);
        sellScreen.GetComponent<SellitemsScroll>().CreateContent();
        manager.HideDialog();
        playerController.playerTalking = true;
        DestroyButtons();
    }


    public void DestroyButtons()
    {
        Destroy(buyButtonGO);
        Destroy(sellButtonGO);
    }
}
