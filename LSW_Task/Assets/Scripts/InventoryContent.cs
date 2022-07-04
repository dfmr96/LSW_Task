using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class InventoryContent : MonoBehaviour
{
    public List<ItemInfo> inventoryPool;
    [SerializeField] GameObject inventoryBoxPrefab;
    [SerializeField] GameObject content;
    [SerializeField] GameObject firstChild;
    [SerializeField] List<GameObject> children;
    public SpriteRenderer equippedShirt, equippedPants, equippedShoes;

    private void Start()
    {
        inventoryPool = new List<ItemInfo>();
    }

    public void CreateContent()
    {
        

        foreach (GameObject child in children)
        {
            Destroy(child);
        }

        children = new List<GameObject>();

        for (int i = 0; i < inventoryPool.Count; i++)
        {

            var inventoryBoxGO = Instantiate(inventoryBoxPrefab);
            inventoryBoxGO.GetComponent<InventoryItemBoxInfo>().SetItemInfo(inventoryPool[i]);
            inventoryBoxGO.transform.SetParent(content.transform, true);
            children.Add(inventoryBoxGO);
        }

        if (children.Count > 0)
        {
        firstChild = children[0];
        EventSystem.current.SetSelectedGameObject(firstChild);
            Debug.Log(firstChild);
        }
    }

}

