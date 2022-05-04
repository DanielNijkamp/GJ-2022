using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private GameObject playerobject;

    public float startinghealth;
    public float health;
    bool hasdied;
    private WaveSpawner wavemanager;
    // Start is called before the first frame update
    void Start()
    {
        wavemanager = FindObjectOfType<WaveSpawner>();
        health = startinghealth;
        playerobject = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasdied)
        {
            if (this.health <= 0)
            {
                Die();
                hasdied = true;
            }
            player = playerobject.transform;
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        
    }
    private void FixedUpdate()
    {
        if (!hasdied)
        {
            moveCharacter(movement);
        }
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().DamagePlayer(30f);
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
    }
    private void Die()
    {
        wavemanager.currentroomscript.currentenemies.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
    
}
