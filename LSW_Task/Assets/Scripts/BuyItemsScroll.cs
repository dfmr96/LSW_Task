using UnityEngine;
using UnityEngine.EventSystems;


public class BuyItemsScroll : MonoBehaviour
{
    [SerializeField] GameObject itemBoxPrefab;
    [SerializeField] GameObject[] itemPrefab;
    [SerializeField] GameObject content;
    [SerializeField] ItemInfo[] itemInfo;
    public GameObject firstChild;
    public bool objectsCreated = false;

    private void Update()
    {
        if (this.gameObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void CreateContent()
    {
        itemInfo = new ItemInfo[5];
        itemInfo[0] = ScriptableObject.CreateInstance<ItemInfo>().Init("Camisa Azul", 1);
        itemInfo[1] = ScriptableObject.CreateInstance<ItemInfo>().Init("Camisa Roja", 2);
        itemInfo[2] = ScriptableObject.CreateInstance<ItemInfo>().Init("Camisa Amarilla", 3);
        itemInfo[3] = ScriptableObject.CreateInstance<ItemInfo>().Init("Camisa Gris", 4);
        itemInfo[4] = ScriptableObject.CreateInstance<ItemInfo>().Init("Camisa Negra", 5);


        for (int i = 0; i < 5; i++)
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
