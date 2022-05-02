using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCheck : MonoBehaviour
{
    public bool AnimationPlayed;
    private bool Entered;
    private void Awake()
    {
        AnimationPlayed = false;
        Entered = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (AnimationPlayed && !Entered)
            {
                FindObjectOfType<FloorSystem>().AdvanceFloor();
                Entered = true;
            }
           
        }
    }
}
