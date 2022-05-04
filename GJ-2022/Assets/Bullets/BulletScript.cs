using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletdamage;
    public bool isplayer;

    [SerializeField] private bool donedamage;
    [SerializeField] private float bulletLifeTime;
    private void Start()
    {
        
        this.donedamage = false;
    }
    private void FixedUpdate()
    {
        this.transform.position += transform.right * bulletSpeed * Time.deltaTime;
        if (this != null)
        {
            Destroy(gameObject, bulletLifeTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this.donedamage)
        {
            if (isplayer)
            {
                if (collision.CompareTag("Boss"))
                {
                    collision.GetComponent<BossScript>().TakeDamage(bulletdamage);
                    this.donedamage = true;
                    Destroy(this.gameObject);
                }
                if (collision.CompareTag("Enemy"))
                {
                    collision.GetComponent<BaseEnemy>().TakeDamage(bulletdamage);
                    this.donedamage = true;
                    Destroy(this.gameObject);
                }
            }
            else
            {
                if (collision.CompareTag("Player"))
                {
                    collision.GetComponent<Player>().DamagePlayer(bulletdamage);
                    this.donedamage = true;
                    Destroy(this.gameObject);
                }
            }
        }     
    }

}
