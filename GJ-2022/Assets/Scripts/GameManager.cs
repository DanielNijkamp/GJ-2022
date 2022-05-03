using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Animator anim;
    public float slowDownDuration;
    public GameObject DeathUI;
    public GameObject PauseUI;

    public GameObject DeathBackground;
    public GameObject PauseBackground;

    private bool IsPaused;
    private bool isCoolDown = false;

    private Player player;
    public PlayerRotation PlayerRotation;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isCoolDown == false && !player.hasDied)
            {
                if (IsPaused)
                {
                    StartCoroutine(Unpause());
                    
                }
                else
                {
                    StartCoroutine(Pause());
                }
                StartCoroutine(CoolDown());
            }

        }
    }
    public void SlowDownTime()
    {
        StartCoroutine(ChangeTime(1f, 0.1f, slowDownDuration));
    }
    public void NormalizeTime()
    {
        StartCoroutine(ChangeTime(0.1f, 1f, slowDownDuration));
    }
    
    IEnumerator ChangeTime(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            Time.timeScale = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        Time.timeScale = v_end;
    }
    public void DeathScreen()
    {
        StartCoroutine(EnableDeathUI());
    }
    IEnumerator Pause()
    {
        PlayerRotation.enabled = false;
        IsPaused = true;
        PauseBackground.SetActive(true);
        SlowDownTime();
        anim.Play("Pause_Fade_In");
        yield return new WaitForSecondsRealtime(slowDownDuration);
        PauseUI.SetActive(true);
        anim.Play("Pause_UI_Fade_In");
        
    }
    IEnumerator Unpause()
    {
        PlayerRotation.enabled = true;
        IsPaused = false;
        anim.Play("Pause_UI_Fade_Out");
        yield return new WaitForSecondsRealtime(0.51f);
        PauseUI.SetActive(false);

        anim.Play("Pause_Fade_Out");
        yield return new WaitForSecondsRealtime(slowDownDuration);
        NormalizeTime();
        PauseBackground.SetActive(false);
        
    }
    IEnumerator EnableDeathUI()
    {
        PlayerRotation.enabled = false;
        DeathBackground.SetActive(true);
        anim.Play("Death_Fade_In");
        yield return new WaitForSecondsRealtime(1f);
        DeathUI.SetActive(true);
        anim.Play("Death_UI_Fade_In");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        ResetGameValues();
    }
    private void ResetGameValues()
    {

    }
    public void Save_Quit()
    {

    }
    IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSecondsRealtime(1f);
        isCoolDown = false;
    }
}
