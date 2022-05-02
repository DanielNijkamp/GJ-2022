using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_Handler : MonoBehaviour
{
    private RoomTemplates templates;
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.MM_Objects.Add(this.gameObject);
    }
}
