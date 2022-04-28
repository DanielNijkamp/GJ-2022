using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float normalspeed;
    public float runspeed;

    private Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousepos;

    private bool isMoving;

    public Camera cam;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

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

        Vector2 lookdir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    
}
