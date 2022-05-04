using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    private CoverScript manager;
    private WaveSpawner wavespawner;
    public List<GameObject> currentenemies;

    public bool spawnedenemies = false;
    public bool isHallway;

    private void Start()
    {
        manager = FindObjectOfType<CoverScript>();
        wavespawner = FindObjectOfType<WaveSpawner>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject newcover = Instantiate(manager.coverprefab, this.transform.position, Quaternion.identity);
            manager.Covers.Add(newcover);
            manager.CheckedForPlayer = false;

            if (!this.transform.parent.gameObject.CompareTag("Entry"))
            {
                if (!this.isHallway)
                {
                    wavespawner.currentroom = this.gameObject;
                    wavespawner.currentroomscript = this;
                    wavespawner.StartWave(this.transform.parent.gameObject);
                }
            }
        }
        
    }
   
    
}