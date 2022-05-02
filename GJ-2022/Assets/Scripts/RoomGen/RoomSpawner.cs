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
    private int rand;
    private int room_rand;
    private float waittime = 6f;
    private void Start()
    {
        Destroy(gameObject, waittime);
        spawned = false;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.5f);
    }
    public void Spawn()
    {
        if (!spawned)
        {
            room_rand = Random.Range(0, 4);
            if (room_rand == 0)
            {
                SpawnCorridor();
                spawned = true;
            }
            else
            {
                SpawnRoom();
                spawned = true;
            }
             
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Entry"))
        {
            this.spawned = true;
            Destroy(gameObject);
        }
        if (collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false && transform.position.x != 0 && transform.position.y != 0)
            {
                Instantiate(templates.closedroom.gameObject, transform.position, Quaternion.identity);
                Instantiate(templates.minimap_prefabs[0], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            this.spawned = true;
        }
    }
    void SpawnCorridor()
    {
        if (OpeningDirection == 3 || OpeningDirection == 4)
        {
            Instantiate(templates.Corridors[0], transform.position, Quaternion.identity);
            Instantiate(templates.Floors[1], transform.position, Quaternion.identity);
            Instantiate(templates.MM_Corridors[0], transform.position, Quaternion.identity);
        }
        else if (OpeningDirection == 1 || OpeningDirection == 2)
        {
            Instantiate(templates.Corridors[1], transform.position, Quaternion.identity);
            Instantiate(templates.Floors[2], transform.position, Quaternion.identity);
            Instantiate(templates.MM_Corridors[1], transform.position, Quaternion.identity);
        }
        this.spawned = true;
        return;
        
    }
    void SpawnRoom()
    {
        Instantiate(templates.Floors[0], transform.position, Quaternion.identity);
        switch (this.OpeningDirection)
        {
            case 1:
                rand = Random.Range(0, templates.bottomrooms.Length - 1);
                Instantiate(templates.bottomrooms[rand], transform.position, Quaternion.identity);
                Instantiate(templates.MM_bottomrooms[rand], transform.position, Quaternion.identity);
                break;
            case 2:
                rand = Random.Range(0, templates.toprooms.Length - 1);
                Instantiate(templates.toprooms[rand], transform.position, Quaternion.identity);
                Instantiate(templates.MM_toprooms[rand], transform.position, Quaternion.identity);
                break;
            case 3:
                rand = Random.Range(0, templates.leftrooms.Length - 1);
                Instantiate(templates.leftrooms[rand], transform.position, Quaternion.identity);
                Instantiate(templates.MM_leftrooms[rand], transform.position, Quaternion.identity);
                break;
            case 4:
                rand = Random.Range(0, templates.rightrooms.Length - 1);
                Instantiate(templates.rightrooms[rand], transform.position, Quaternion.identity);
                Instantiate(templates.MM_rightrooms[rand], transform.position, Quaternion.identity);
                break;
        }

        this.spawned = true;
        return;
    }

}
