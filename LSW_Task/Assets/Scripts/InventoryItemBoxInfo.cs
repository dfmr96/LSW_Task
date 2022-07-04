using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryItemBoxInfo : MonoBehaviour
{
    public TMP_Text itemName, itemPrice;
    public Image image;
    [SerializeField] InventoryContent inventoryContent;
    private void Start()
    {
        inventoryContent = FindObjectOfType<InventoryContent>();

        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new()
        {
            eventID = EventTriggerType.Submit
        };
        entry.callback.AddListener((functionIWant) => { EquipItem(); });
        trigger.triggers.Add(entry);
    }
    public void SetItemInfo(ItemInfo itemInfo)
    {
        itemName.text = itemInfo.itemName;
        itemPrice.text = itemInfo.itemPrice.ToString();
        image.sprite = itemInfo.sprite;
    }
    public void EquipItem()
    {
        if (image.sprite.name.Contains("shirt"))
        {
            inventoryContent.equippedShirt.sprite = image.sprite;
        }

        if (image.sprite.name.Contains("pants"))
        {
            inventoryContent.equippedPants.sprite = image.sprite;
        }

        if (image.sprite.name.Contains("shoes"))
        {
            inventoryContent.equippedShoes.sprite = image.sprite;
        }
    }
}
