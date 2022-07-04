using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int speed = 5;
    private const string horizontal = "Horizontal", vertical = "Vertical";
    Vector2 movementDirection;
    public bool playerTalking;
    public GameObject inventoryScreen;
    public GameObject inventoryContent;
    bool objectsCreated;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTalking = false;
        objectsCreated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTalking)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        //Player Movement

        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0f || (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0)) //GetAxisRaw for values of -1 (left, down), 0 or 1 (right, up) in Unity Input System; Mathf.Abs to return |-1| values and active condition.
        {
            movementDirection = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical)); // Catch vector2 movement direction
            rb.velocity = movementDirection.normalized * speed; //normalize to get movement direction and increase the vector magnitude with * speed
        }
        else
        {
            rb.velocity = Vector2.zero; //if player dont use movement buttons, gameobject will stop
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }

        if(inventoryScreen.activeInHierarchy)
        {
            rb.velocity = Vector2.zero;
        }


    }

    public void ShowInventory()
    {

        if (inventoryScreen.activeInHierarchy == false)
        {
            inventoryScreen.SetActive(true);
            inventoryContent.GetComponent<InventoryContent>().CreateContent();
            
        }
        else
        {
            inventoryScreen.SetActive(false);
        }



    }
}
