using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloorSystem : MonoBehaviour
{
    private RoomTemplates templates;
    public float floorlevel;
    public TextMeshProUGUI floor_text;
    public GameObject fadecanvas;

    private void Start()
    {
        templates = FindObjectOfType<RoomTemplates>();
    }
    public void AdvanceFloor()
    {
        templates.ResetBossTimer();
        StartCoroutine(TransitionFloor());
    }
    
    private void OnGUI()
    {
        floor_text.text = floorlevel.ToString();
    }
    public void ClearFloor()
    {
        if (templates.rooms != null)
        {
            for (int i = 0; i < templates.rooms.Count; i++)
            {
                Destroy(templates.rooms[i].gameObject);
            }
            templates.rooms.Clear();
        }
        if (templates.MM_Objects != null)
        {
            for (int i = 0; i < templates.MM_Objects.Count; i++)
            {
                Destroy(templates.MM_Objects[i].gameObject);
            }
            templates.MM_Objects.Clear();
        }
        if (templates.floors != null)
        {
            for (int i = 0; i < templates.floors.Count; i++)
            {
                Destroy(templates.floors[i].gameObject);
            }
            templates.floors.Clear();
        }
        if (templates.decorations != null)
        {
            for (int i = 0; i < templates.decorations.Count; i++)
            {
                Destroy(templates.decorations[i].gameObject);
            }
            templates.decorations.Clear();
        }
    }
    IEnumerator TransitionFloor()
    {
        //animation
        fadecanvas.GetComponent<Animator>().Play("CanvasFadeIn");
        yield return new WaitForSecondsRealtime(0.55f);
        fadecanvas.GetComponent<Animator>().Play("CanvasFadeOut");

        //generate level & update UI
        floorlevel += 1;
        ClearFloor();
        FindObjectOfType<Player>().ResetPosition();
        templates.SpawnRoom();
    }
}
