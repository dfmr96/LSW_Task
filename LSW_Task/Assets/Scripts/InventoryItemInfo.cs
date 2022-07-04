using TMPro;
using UnityEngine;

public class InventoryItemInfo : ScriptableObject
{
    public string itemName;
    public int itemPrice;
    public InventoryItemInfo Init(string itemName, int itemPrice)
    {
        this.itemName = itemName;
        this.itemPrice = itemPrice;
        return this;
    }
}
