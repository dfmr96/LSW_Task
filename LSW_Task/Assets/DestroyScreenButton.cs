using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyScreenButton : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] BuyItemsScroll buyScreen;

    private void Start()
    {
        buyScreen = FindObjectOfType<BuyItemsScroll>();
        EventSystem.current.SetSelectedGameObject(button);
    }
    public void DestroyScreen()
    {
        Destroy(gameObject);
        EventSystem.current.SetSelectedGameObject(buyScreen.firstChild);
    }
}
