using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]private Animator[] x_anim;
    [SerializeField]private Animator[] y_anim;

    public GameObject enemyprefab;
    public GameObject bossroom;
    public GameObject currentroom;

    public GameObject spawnarea;
    public PlayerCheck currentroomscript;
    private bool lockedroom;
    public void StartWave(GameObject currentroom)
     {
        x_anim = currentroom.GetComponentsInChildren<Animator>();
        y_anim = currentroom.GetComponentsInChildren<Animator>();
        StartCoroutine(CloseAnim());
        SpawnEnemies();
        
    }
    private void Update()
    {
        if (currentroom != null && currentroomscript != null)
        {
            if (currentroomscript.currentenemies == null || currentroomscript.currentenemies.Count == 0 && currentroomscript.spawnedenemies)
            {
                if (lockedroom)
                {
                    Debug.Log("Enemies have been cleared");
                    StartCoroutine(OpenAnim());
                }
            }
        }
    }

    IEnumerator OpenAnim()
    {
        lockedroom = false;
        yield return new WaitForSecondsRealtime(0.1f);
        if (x_anim != null)
        {
            foreach (Animator anim in x_anim)
            {
                anim.Play("X_Open");
            }
        }
        if (y_anim != null)
        {
            foreach (Animator anim in y_anim)
            {
                anim.Play("Y_Open");
            }
        }
        
        
    }
    IEnumerator CloseAnim()
    {
        lockedroom = true;
        yield return new WaitForSecondsRealtime(0.1f);
        if (x_anim != null)
        {
            foreach (Animator anim in x_anim)
            {
                anim.Play("X_Close");
            }
        }
        if (y_anim != null)
        {
            foreach (Animator anim in y_anim)
            {
                anim.Play("Y_Close");
            }
        }
    }
    public void SpawnEnemies()
    {
        spawnarea.transform.position = currentroom.transform.position;
        int rand = Random.Range(1, 7);
        for (int i = 0; i < rand; i++)
        {
            GameObject newenemy = Instantiate(enemyprefab, spawnarea.transform.position, Quaternion.identity);

            currentroomscript.currentenemies.Add(newenemy);
            
        }
        currentroomscript.spawnedenemies = true;
    }
}
