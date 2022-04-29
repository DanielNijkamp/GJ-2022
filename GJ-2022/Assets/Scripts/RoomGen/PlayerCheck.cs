using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    private CoverScript manager;

    private void Start()
    {
        manager = FindObjectOfType<CoverScript>();    
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject newcover = Instantiate(manager.coverprefab, this.transform.position, Quaternion.identity);
            manager.Covers.Add(newcover);
            manager.CheckedForPlayer = false;
        }
        
    }
   
    
}