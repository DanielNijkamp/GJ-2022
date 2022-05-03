using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletdamage;

    public string BulletTag;
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
        if (collision.CompareTag(BulletTag))
        {
            if (!this.donedamage)
            {
               switch (BulletTag)
               {
                    case "Player":
                        collision.GetComponent<Player>().DamagePlayer(bulletdamage);
                        this.donedamage = true;
                        Destroy(this.gameObject);
                        break;
                    case "Enemy":
                        // damage enemy
                        break;
               }
            }
            
        }
        
        
    }

}
