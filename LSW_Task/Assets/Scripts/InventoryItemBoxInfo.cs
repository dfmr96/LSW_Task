using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItemBoxInfo : MonoBehaviour
{
    public TMP_Text itemName, itemPrice;
    public Image image;

    public void SetItemInfo(ItemInfo itemInfo)
    {
        itemName.text = itemInfo.itemName;
        itemPrice.text = itemInfo.itemPrice.ToString();
        image.sprite = itemInfo.sprite;
    }
}
