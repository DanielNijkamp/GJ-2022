using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(OpenDoorAnimation());
        }
    }
    IEnumerator OpenDoorAnimation()
    {
        this.GetComponentInParent<Animator>().Play("OpenDoor");
        this.GetComponentInParent<LevelCheck>().AnimationPlayed = true;
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(gameObject);
    }
}
