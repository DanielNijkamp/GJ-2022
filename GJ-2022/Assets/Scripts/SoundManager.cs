using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    private bool bgm_muted = false;
    private bool sfx_muted = false;

    public AudioSource bgmsource;
    public AudioSource sfxsource;

    public Sprite[] BGM_UI;
    public Sprite[] SFX_UI;

    public Image BGM_Icon;
    public Image SFX_Icon;

    private float bgm_volume = 0.5f;
    private float sfx_volume = 0.5f;
    private void Update()
    {
        bgmsource.volume = bgm_volume;
        sfxsource.volume = sfx_volume;
    }
    public void BGM_Button()
    {
        if (bgm_muted) // if muted turn on
        {
            bgm_volume = 0.5f; 
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
            sfx_volume = 0.5f;
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
}
