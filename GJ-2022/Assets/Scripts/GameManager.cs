using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float slowDownFactor = 0f;
    public float slowDownDuration = 2f;

    

    private void Update()
    {
        print( Time.timeScale);
        Time.timeScale += (0.1f / slowDownDuration) * Time.unscaledDeltaTime;
        Time.fixedDeltaTime += (0.01f / slowDownDuration) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        Time.fixedDeltaTime = Mathf.Clamp(Time.fixedDeltaTime, 0f, 0.01f);
    }
    public void SlowDownTime()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;
    }
    public void NormalizeTime()
    {
        
    }
}
