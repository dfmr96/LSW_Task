using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SellitemsScroll : MonoBehaviour
{
    [SerializeField] GameObject itemBoxPrefab;
    [SerializeField] GameObject content;
    [SerializeField] InventoryContent inventoryContent;
    [SerializeField] List<GameObject> children;
    [SerializeField] GameObject firstChild;
    private void Update()
    {
        if (this.gameObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void CreateContent()
    {
        foreach (GameObject child in children)
        {
            Destroy(child);
        }
        children = new List<GameObject>();

        for (int i = 0; i < inventoryContent.inventoryPool.Count; i++)
        {
            var itemToSellGO = Instantiate(itemBoxPrefab);
            itemToSellGO.GetComponent<ItemBoxInfo>().SetItemInfo(inventoryContent.inventoryPool[i]);
            itemToSellGO.transform.SetParent(content.transform, true);
            children.Add(itemToSellGO);
        }
        if (children.Count > 0)
        {
            firstChild = children[0];
            EventSystem.current.SetSelectedGameObject(firstChild);
            Debug.Log(firstChild);
        }
    }
}
