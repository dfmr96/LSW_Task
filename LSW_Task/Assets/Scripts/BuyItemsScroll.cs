using UnityEngine;
using UnityEngine.EventSystems;


public class BuyItemsScroll : MonoBehaviour
{
    [SerializeField] GameObject itemBoxPrefab;
    [SerializeField] GameObject[] itemPrefab;
    [SerializeField] GameObject content;
    [SerializeField] NPCInventory npcInventory;
    public ItemInfo[] itemInfo;

    public GameObject firstChild;
    public bool objectsCreated = false;
    [SerializeField] SpritesClothes sprite;

    private void Update()
    {
        if (this.gameObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void CreateContent()
    {
        itemInfo = npcInventory.itemInfo;
        for (int i = 0; i < itemInfo.Length; i++)
        {
            var itemBoxGO = Instantiate(itemBoxPrefab);
            itemBoxGO.GetComponent<ItemBoxInfo>().SetItemInfo(itemInfo[i]);
            itemBoxGO.transform.SetParent(content.transform, true);

        }

        firstChild = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        EventSystem.current.SetSelectedGameObject(firstChild);

        objectsCreated = true;
    }
}
