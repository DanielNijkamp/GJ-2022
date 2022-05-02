using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFloor : MonoBehaviour
{
    private RoomTemplates templates;
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.floors.Add(this.gameObject);
    }
}
