using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    private RoomTemplates templates;
    public int OpeningDirection;
    // 1 = bottom
    // 2 = top
    // 3 = left
    // 4 = right
    public bool spawned;

    private void Start()
    {
        spawned = false;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }
    public void Spawn()
    {
        if (!spawned)
        {
            switch (OpeningDirection)
            {
                case 1:
                    Instantiate(templates.bottomrooms[Random.Range(0, templates.bottomrooms.Length)], transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(templates.toprooms[Random.Range(0, templates.toprooms.Length)], transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(templates.leftrooms[Random.Range(0, templates.leftrooms.Length)], transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(templates.rightrooms[Random.Range(0, templates.rightrooms.Length)], transform.position, Quaternion.identity);
                    break;

            }
            
        }
        this.spawned = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint") && collision.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(this.gameObject);
        }
    }
}
