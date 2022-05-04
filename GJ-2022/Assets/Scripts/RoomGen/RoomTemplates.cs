using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] minimap_prefabs;

    public GameObject[] toprooms;
    public GameObject[] bottomrooms;
    public GameObject[] leftrooms;
    public GameObject[] rightrooms;


    public GameObject[] MM_toprooms;
    public GameObject[] MM_bottomrooms;
    public GameObject[] MM_leftrooms;
    public GameObject[] MM_rightrooms;

    public GameObject[] MM_Corridors;
    public GameObject[] Corridors;

    public GameObject[] StartingObjects;
    
    public GameObject[] Floors;
    public GameObject[] Decoration_Prefabs;

    public GameObject closedroom;
    public GameObject PlayerIcon;


    public List<GameObject> rooms;
    public List<GameObject> MM_Objects;
    public List<GameObject> floors;
    public List<GameObject> decorations;

    private float base_wait_time;
    public float waittime;
    private bool spawnedBoss;
    public GameObject boss;
    public GameObject leveldoor;

    private GameObject playericon;
    private GameObject Player_Object;

    private RoomTemplates roomtemplates;
    private GameObject bossroom;
    private void Awake()
    {
        SpawnRoom();
    }
    private void Start()
    {
        base_wait_time = waittime;
        playericon = Instantiate(PlayerIcon);
        roomtemplates = FindObjectOfType<RoomTemplates>();
        Player_Object = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        playericon.transform.position = Player_Object.transform.position;
        if (waittime <= 0 && !spawnedBoss)
        {
            bossroom = rooms[rooms.Count - 1].gameObject;
            FindObjectOfType<WaveSpawner>().bossroom = bossroom;
            Instantiate(roomtemplates.minimap_prefabs[1], rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            GameObject gameObject = Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            PrepareBossRoom();
            spawnedBoss = true;
        }
        else
        {
            waittime -= Time.deltaTime;
        }
    }
    public void SpawnRoom()
    {
        foreach (GameObject item in StartingObjects)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
        
    }
    public void ResetBossTimer()
    {
        waittime = base_wait_time;
        spawnedBoss = false;

    }
    public void PrepareBossRoom()
    {
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("Wall_Deco"))
        {
            if (wall.transform.position == bossroom.transform.position)
            {
                GameObject lights = Instantiate(roomtemplates.Decoration_Prefabs[0], wall.transform.position, Quaternion.identity);
                decorations.Add(lights);
                Destroy(wall);
                print("Removed wall in boss room");
                break;
                
            }
        }
    }
}
