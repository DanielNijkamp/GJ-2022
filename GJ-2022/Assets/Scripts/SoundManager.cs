using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    private bool bgm_muted = false;
    private bool sfx_muted = false;
    private bool isCoolDown = false;

    public Sprite[] BGM_UI;
    public Sprite[] SFX_UI;

    public Image BGM_Icon;
    public Image SFX_Icon;

    private float bgm_volume = 0.5f;
    private float sfx_volume = 0.5f;
    public void test()
    {
        print("test");
    }
    public void BGM_Button()
    {
        if (bgm_muted) // if muted turn on
        {
            bgm_volume = 0.5f; 
            BGM_Icon.sprite = BGM_UI[1];
            bgm_muted = false;
            print("BGM On");
        }
        else // if not muted turn off
        {
            bgm_volume = 0f; 
            BGM_Icon.sprite = BGM_UI[0];
            bgm_muted = true;
            print("BGM Off");
        }
    }
    public void SFX_Button()
    {
        if (sfx_muted) // if muted turn on
        {
            sfx_volume = 0.5f;
            SFX_Icon.sprite = SFX_UI[1];
            sfx_muted = false;
            print("SFX On");
        }
        else // if not muted turn off
        {
            sfx_volume = 0f;
            SFX_Icon.sprite = SFX_UI[0];
            sfx_muted = true;
            print("SFX off");
        }
    }
}
