using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverScript : MonoBehaviour
{
    public GameObject coverprefab;
    public List<GameObject> Covers;
    public GameObject OldCover;
    public GameObject NewCover;

    public bool CheckedForPlayer;

    private void Start()
    {
        CheckedForPlayer = false;
    }
    private void Update()
    {
        if (!CheckedForPlayer)
        {
            if (Covers.Count != 0)
            {
                Covers[0].GetComponent<Animator>().Play("FadeIn");
            }
            if (Covers.Count > 1)
            {
                Covers[1].GetComponent<Animator>().Play("FadeIn");
                StartCoroutine(FadeOut());
            }
        }
        
    }
    IEnumerator FadeOut()
    {
        GameObject object_to_destroy = Covers[0].gameObject;
        CheckedForPlayer = true;
        Covers[0].GetComponent<Animator>().Play("FadeOut");
        Covers.Remove(Covers[0]);
        yield return new WaitForSeconds(1f);
        Destroy(object_to_destroy);
        
    }
}
