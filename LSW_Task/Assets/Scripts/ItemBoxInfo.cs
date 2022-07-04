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

 

    private void Start()
    {
        inventoryContent = FindObjectOfType<InventoryContent>().gameObject;
        sellerPool = FindObjectOfType<BuyItemsScroll>();
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new()
        {
            eventID = EventTriggerType.Submit
        };
        entry.callback.AddListener((functionIWant) => { AddItemToInventoryList(); });
        trigger.triggers.Add(entry);
    }
    public void SetItemInfo(ItemInfo itemInfo)
    {
        this.itemInfo = itemInfo;
        itemName.text = itemInfo.itemName;
        itemPrice.text = itemInfo.itemPrice.ToString();
    }
    
    public void AddItemToInventoryList()
    {
        inventoryContent.GetComponent<InventoryContent>().inventoryPool.Add(this.itemInfo);
    }
  /*  public void SetInventoryItemInfo()
    {
        GameObject _newItem = Instantiate(itemInstance, parentGO.transform);
        _newItem.GetComponent<InventoryItemInfo>().itemName.text = this.itemName.text;
        Debug.Log(_newItem.GetComponent<InventoryItemInfo>().itemName.text);
        _newItem.GetComponent<InventoryItemInfo>().itemPrice.text = this.itemPrice.text;
    }
  */
}
