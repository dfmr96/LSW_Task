using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInventory : MonoBehaviour
{
    public ItemInfo[] itemInfo;
    [SerializeField] SpritesClothes sprite;

    private void Start()
    {
        itemInfo = new ItemInfo[11];
        itemInfo[0] = ScriptableObject.CreateInstance<ItemInfo>().Init("Red Shirt", 50, sprite.sprite[0]);
        itemInfo[1] = ScriptableObject.CreateInstance<ItemInfo>().Init("Grey Pants", 25, sprite.sprite[1]);
        itemInfo[2] = ScriptableObject.CreateInstance<ItemInfo>().Init("Black Shoes", 10, sprite.sprite[2]);
        itemInfo[3] = ScriptableObject.CreateInstance<ItemInfo>().Init("Blue Pants", 4, sprite.sprite[3]);
        itemInfo[4] = ScriptableObject.CreateInstance<ItemInfo>().Init("Blue Shirt", 5, sprite.sprite[4]);
        itemInfo[5] = ScriptableObject.CreateInstance<ItemInfo>().Init("Blue Shoes", 50, sprite.sprite[5]);
        itemInfo[6] = ScriptableObject.CreateInstance<ItemInfo>().Init("Green Pants", 25, sprite.sprite[6]);
        itemInfo[7] = ScriptableObject.CreateInstance<ItemInfo>().Init("Green Shirt", 10, sprite.sprite[7]);
        itemInfo[8] = ScriptableObject.CreateInstance<ItemInfo>().Init("Green Shoes", 4, sprite.sprite[8]);
        itemInfo[9] = ScriptableObject.CreateInstance<ItemInfo>().Init("Yellow Shirt", 5, sprite.sprite[9]);
        itemInfo[10] = ScriptableObject.CreateInstance<ItemInfo>().Init("Yellow Pants", 5, sprite.sprite[10]);
    }
}
