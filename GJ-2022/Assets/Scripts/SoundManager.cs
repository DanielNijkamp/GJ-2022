using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{

    private static SoundManager soundmanager;
    private bool bgm_muted = false;
    private bool sfx_muted = false;

    public AudioSource bgmsource;
    public AudioSource sfxsource;

    public Sprite[] BGM_UI;
    public Sprite[] SFX_UI;

    public AudioClip[] BGM;
    public AudioClip[] SFX;

    public Image BGM_Icon;
    public Image SFX_Icon;

    public bool GameStarted;

    private float bgm_volume = 0.1f;
    private float sfx_volume = 0.1f;
    private void Start()
    {
        StartCoroutine(MainMenuBGM());
    }
    private void Update()
    {
        bgmsource.volume = bgm_volume;
        sfxsource.volume = sfx_volume;
    }
    IEnumerator MainMenuBGM()
    {
        bgmsource.clip = BGM[0];
        bgmsource.PlayOneShot(bgmsource.clip);
        yield return new WaitForSecondsRealtime(bgmsource.clip.length);
        StartCoroutine(MainMenuBGM());
    }
    public IEnumerator StartBGMMusic()
    {
        if (GameStarted)
        {
            bgmsource.clip = BGM[1];
            bgmsource.Play(0);
            yield return new WaitForSecondsRealtime(bgmsource.clip.length);
            StartCoroutine(StartBGMMusic());
        }
    }
    public void StopMusic()
    {
        bgmsource.Stop();
        GameStarted = true;
    }
    public void BGM_Button()
    {
        if (bgm_muted) // if muted turn on
        {
            bgm_volume = 0.1f; 
            BGM_Icon.sprite = BGM_UI[1];
            bgm_muted = false;
        }
        else // if not muted turn off
        {
            bgm_volume = 0f; 
            BGM_Icon.sprite = BGM_UI[0];
            bgm_muted = true;
        }
    }
    public void SFX_Button()
    {
        if (sfx_muted) // if muted turn on
        {
            sfx_volume = 0.1f;
            SFX_Icon.sprite = SFX_UI[1];
            sfx_muted = false;
        }
        else // if not muted turn off
        {
            sfx_volume = 0f;
            SFX_Icon.sprite = SFX_UI[0];
            sfx_muted = true;
        }
    }
    public void ShootSound()
    {
        sfxsource.clip = SFX[0];
        sfxsource.PlayOneShot(sfxsource.clip);
    }
    private void Awake()
    {
        if (!soundmanager)
        {
            DontDestroyOnLoad(gameObject);
            soundmanager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
