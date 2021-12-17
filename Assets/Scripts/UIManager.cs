using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    //UI
    public TMP_Text healthText;
    public TMP_Text corruptionText;
    //Visual
    public Slider healthBar;
    public Slider corruptionBar;
    //Screens
    public GameObject gameOverScreen;
    public GameObject menuScreen;
    public GameObject weaponScreen;
    public GameObject itemScreen;
    public GameObject materialScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        menuScreen.SetActive(false);
        weaponScreen.SetActive(false);
        itemScreen.SetActive(false);
        materialScreen.SetActive(false);
        healthBar.maxValue = _P.maxHealth;
        corruptionBar.maxValue = _P.maxCorruption;
    }

    //Updates player's new status
    public void UpdateStatus()
    {
        healthBar.value = _P.currentHealth;
        healthText.text = _P.currentHealth + " / " + _P.maxHealth;
    }

    public void UpdateCorruptionTimer(float _timer)
    {
        //updates time on slider
        corruptionBar.value = _timer;
        //timer formating
        _timer += 1; //adjusts timer to display zero only when it hits zero.

        float minutes = Mathf.FloorToInt(_timer / 60); //convert the timer into individual minutes and seconds as integers.
        float seconds = Mathf.FloorToInt(_timer % 60);

        corruptionText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //Display timer in minute:second format
    }

    public void GameOver(Player _p)
    {
        gameOverScreen.SetActive(true);
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerDied += GameOver;
    }
    private void OnDisable()
    {
        GameEvents.OnPlayerDied -= GameOver;
    }
}
