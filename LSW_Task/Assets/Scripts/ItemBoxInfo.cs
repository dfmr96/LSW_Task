using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemBoxInfo : MonoBehaviour
{
    ItemInfo itemInfo;
    public TMP_Text itemName, itemPrice;
    [SerializeField] GameObject itemInstance;
    [SerializeField] GameObject inventoryContent;
    [SerializeField] BuyItemsScroll sellerPool;
    [SerializeField] GameObject buyScreen, sellScreen;
 

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
    }
    
    public void CopyOrEraseItem()
    {
        if (buyScreen.activeInHierarchy)
        {
            inventoryContent.GetComponent<InventoryContent>().inventoryPool.Add(this.itemInfo);
        } else
        {
            inventoryContent.GetComponent<InventoryContent>().inventoryPool.Remove(this.itemInfo);
            sellScreen.GetComponent<SellitemsScroll>().CreateContent();
        }
    }
    public void AddItemToInventoryList()
    {
    }
    public void RemoveItemFromInventoryList()
    {
    }

}
