using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryItemBoxInfo : MonoBehaviour
{
    public TMP_Text itemName, itemPrice;

    public void SetItemInfo(ItemInfo itemInfo)
    {
        itemName.text = itemInfo.itemName;
        itemPrice.text = itemInfo.itemPrice.ToString();
    }
}
