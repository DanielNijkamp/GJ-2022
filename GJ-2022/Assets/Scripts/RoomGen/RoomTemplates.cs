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
    
    public GameObject[] Floors;

    public GameObject closedroom;
    public GameObject PlayerIcon;

    public List<GameObject> rooms;

    public float waittime;
    private bool spawnedBoss;
    public GameObject boss;
    public GameObject leveldoor;

    private GameObject playericon;
    private GameObject Player_Object;
    private void Start()
    {
        Player_Object = GameObject.FindGameObjectWithTag("Player");
        playericon = Instantiate(PlayerIcon);
    }
    private void Update()
    {
        playericon.transform.position = Player_Object.transform.position;
        if (waittime <= 0 && !spawnedBoss)
        {
            Instantiate(leveldoor, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            spawnedBoss = true;
        }
        else
        {
            waittime -= Time.deltaTime;
        }
    }
}
