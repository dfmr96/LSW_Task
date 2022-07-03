using UnityEngine;

public class ItemInfo : ScriptableObject
{
    public string itemName;
    public int itemPrice;


    public ItemInfo Init(string itemName, int itemPrice)
    {
        this.itemName = itemName;
        this.itemPrice = itemPrice;
        return this;
    }
}
