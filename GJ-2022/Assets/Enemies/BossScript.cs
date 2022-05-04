using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossScript : MonoBehaviour
{
    public float basehealth;
    public float bosshealth;

    public TextMeshProUGUI health_text;
    public Slider health_slider;
    private bool isShooting;

    public GameObject[] bullets;

    public GameObject LevelStairs;

    public GameObject BulletOrigin;
    public GameObject bullet_direct_origin;

    private GameObject player;
    private Player playerscript;

    private bool clearedbullets = false;

    void Start()
    {
       
        bosshealth = basehealth;
        health_slider.maxValue = basehealth;
        playerscript = FindObjectOfType<Player>();
        player = playerscript.gameObject;
        StartCoroutine(Decision());
    }
    private void Update()
    {
        if (bosshealth <= 0)
        {
            Die();
        }
        if (playerscript.hasDied && !clearedbullets)
        {
            StopAllCoroutines();
            foreach(BulletScript bullet in FindObjectsOfType<BulletScript>())
            {
                Destroy(bullet.gameObject);
            }
            clearedbullets = true; 
        }
    }
    private void OnGUI()
    {
        health_text.text = "Boss Health: " + health_slider.value;
        health_slider.value = bosshealth;

    }
    private void Die()
    {
        Instantiate(LevelStairs, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().DamagePlayer(30f);
        }
    }
    IEnumerator Decision()
    {
        if (!isShooting)
        {
            int rand = Random.Range(0, 2);
            int rand_bullet_type = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    FullCircleAttack(rand_bullet_type, Random.Range(3, 15), Random.Range(0.05f, 0.1f));
                    break;
                case 1:
                    FullCircleAttack(rand_bullet_type, Random.Range(3, 15), 0.05f);
                    break;
            }
        }
        yield return new WaitForSecondsRealtime(0.5f);
        StartCoroutine(Decision());
    }
    public void TakeDamage(float amount)
    {
        bosshealth -= amount;
    }
    public void FullCircleAttack(int bullettype, int scale, float rpm)
    {
        StartCoroutine(Full_Circle_Attack(bullettype, scale, rpm));
    }
    public IEnumerator Full_Circle_Attack(int bullettype, int scale_amount, float time_between_shots)
    {
        isShooting = true;
        for (int angle = 0; angle < 360;)
        {
            BulletOrigin.transform.eulerAngles = new Vector3(0, 0, angle);
            yield return new WaitForSecondsRealtime(time_between_shots);
            Instantiate(bullets[bullettype], BulletOrigin.transform.position, BulletOrigin.transform.rotation);
            angle += scale_amount;
        }
        isShooting = false;
    }
}
