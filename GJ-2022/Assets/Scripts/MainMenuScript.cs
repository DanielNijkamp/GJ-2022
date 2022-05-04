using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void loadnewscene()
    {
        SoundManager soundmanager = FindObjectOfType<SoundManager>();
        soundmanager.StopAllCoroutines();
        soundmanager.StopMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(soundmanager.StartBGMMusic());
    }
    public void Github()
    {
        Application.OpenURL("https://github.com/DanielNijkamp/GJ-2022");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
