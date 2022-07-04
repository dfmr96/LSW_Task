using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemBoxInfo : MonoBehaviour
{
    ItemInfo itemInfo;
    public TMP_Text itemName, itemPrice;
    public Sprite sprite;
    public Image image;
    [SerializeField] GameObject itemInstance;
    [SerializeField] GameObject inventoryContent;
    [SerializeField] BuyItemsScroll sellerPool;
    [SerializeField] GameObject buyScreen, sellScreen, notEnoughtMoneyScreen;
    [SerializeField] GameObject UI;


    private void Start()
    {
        inventoryContent = FindObjectOfType<InventoryContent>().gameObject;
        sellerPool = FindObjectOfType<BuyItemsScroll>();
        buyScreen = FindObjectOfType<NPCDialog>().buyScreen;
        sellScreen = FindObjectOfType<NPCDialog>().sellScreen;
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new()
        {
            eventID = EventTriggerType.Submit
        };
        entry.callback.AddListener((functionIWant) => { CopyOrEraseItem(); });
        trigger.triggers.Add(entry);
    }
    public void SetItemInfo(ItemInfo itemInfo)
    {
        this.itemInfo = itemInfo;
        itemName.text = itemInfo.itemName;
        itemPrice.text = itemInfo.itemPrice.ToString();
        sprite = itemInfo.sprite;
        image.sprite = sprite;
    }

    public void CopyOrEraseItem()
    {
        if (buyScreen.activeInHierarchy)
        {
            if (CurrencyManager.sharedInstance.dollars >= itemInfo.itemPrice)
            {
                CurrencyManager.sharedInstance.dollars -= itemInfo.itemPrice;
                inventoryContent.GetComponent<InventoryContent>().inventoryPool.Add(this.itemInfo);
            } else
            {
                UI = GameObject.FindGameObjectWithTag("UIScreen");
                Instantiate(notEnoughtMoneyScreen, UI.transform);
            }
        }
        else
        {
            inventoryContent.GetComponent<InventoryContent>().inventoryPool.Remove(this.itemInfo);
            sellScreen.GetComponent<SellitemsScroll>().CreateContent();
        }
    }
}
