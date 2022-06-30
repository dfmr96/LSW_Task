using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int speed = 5;
    private const string horizontal = "Horizontal", vertical = "Vertical";
    Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement

        if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0f || (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0)) //GetAxisRaw for values of -1 (left, down), 0 or 1 (right, up) in Unity Input System; Mathf.Abs to return |-1| values and active condition.
        {
            movementDirection = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical)); // Catch vector2 movement direction
            rb.velocity = movementDirection.normalized * speed; //normalize to get movement direction and increase the vector magnitude with * speed
        } else
        {
            rb.velocity = Vector2.zero; //if player dont use movement buttons, gameobject will stop
        }
    }
}