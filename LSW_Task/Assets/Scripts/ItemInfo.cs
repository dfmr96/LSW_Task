using UnityEngine;

public class ItemInfo : ScriptableObject
{
    public string itemName;
    public int itemPrice;
    public Sprite sprite;
    public ItemInfo Init(string itemName, int itemPrice, Sprite sprite)
    {
        this.itemName = itemName;
        this.itemPrice = itemPrice;
        this.sprite = sprite;
        return this;
    }
}
