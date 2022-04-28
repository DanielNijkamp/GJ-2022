using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float normalspeed;
    public float runspeed;
    public Rigidbody2D playermodel_rb;

    private Rigidbody2D rb;
    Vector2 movement;
 

    private bool isMoving;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
             speed = runspeed;
        }
        else
        {
            speed = normalspeed;
        }
    }
    private void FixedUpdate()
    {
        if (movement.x != 0 || movement.y != 0)
        {
            
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        playermodel_rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
    
}
