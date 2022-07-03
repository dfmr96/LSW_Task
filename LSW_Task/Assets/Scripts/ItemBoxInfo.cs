using TMPro;
using UnityEngine;

public class ItemBoxInfo : MonoBehaviour
{
    public TMP_Text itemName, itemPrice;

    public void SetItemInfo(ItemInfo itemInfo)
    {
        itemName.text = itemInfo.itemName;
        itemPrice.text = itemInfo.itemPrice.ToString();
    }
}
