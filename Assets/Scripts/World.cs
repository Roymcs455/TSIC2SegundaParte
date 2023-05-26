using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Constants {
    public const float GAME_TIME = 300;
    public const int LIVES = 10;
}

public class World : MonoBehaviour
{
    public GameObject pelota;
    public GameObject[] panelsUI;
    public TMP_Text timer, lives, winPrompt;
    private float remainingTime;
    private int remainingLives = Constants.LIVES;
    private bool isTimerRunning = false;
    public GameObject[] levels;
    int currentLevel = 0;
    public void Advance()
    {
        currentLevel++;
        switch (currentLevel)
        {   
            default:
                currentLevel = 0;
                levels[0].SetActive(true);
                levels[1].SetActive(false);
                levels[2].SetActive(false);
            break;
            case 0:
                levels[0].SetActive(true);
                levels[1].SetActive(false);
                levels[2].SetActive(false);
            break;
            case 1:
                levels[0].SetActive(false);
                levels[1].SetActive(true);
                levels[2].SetActive(false);

            break;
            case 2:
                levels[0].SetActive(false);
                levels[1].SetActive(false);
                levels[2].SetActive(true);
            break;
            case 3:
                levels[0].SetActive(false);
                levels[1].SetActive(false);
                levels[2].SetActive(false);
                WinGame();
                
            break;
        }

    }
    private void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(remainingTime / 60);
        float seconds = Mathf.FloorToInt(remainingTime % 60);
        timer.text = string.Format("Time left: {0:00}:{1:00}",minutes,seconds);
    }

    public void Update()
    {
        if (isTimerRunning)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                DisplayTime();
            }
            else
            {
                GameOver();
            }
        }
    }
    public void StartGame()
    {
        remainingTime = Constants.GAME_TIME;
        remainingLives = Constants.LIVES;
        Debug.Log("Lives: "+remainingLives);
        panelsUI[0].SetActive(false);
        panelsUI[1].SetActive(true);
        panelsUI[2].SetActive(false);
        isTimerRunning = true;
        levels[0].SetActive(true);
        pelota.SetActive(true);
    }
    public void GameOver()
    {
        panelsUI[0].SetActive(false);
        panelsUI[1].SetActive(false);
        panelsUI[2].SetActive(true);
        isTimerRunning = false;
        Debug.Log("Juego Terminado");
        pelota.SetActive(false);
    }
    public void WinGame()
    {
        panelsUI[1].SetActive(false);
        panelsUI[3].SetActive(true);
        isTimerRunning = false;
        pelota.SetActive(false);
        winPrompt.text = string.Format("lives left: {0} \nTime Left: {1:00}:{2:00}",remainingLives,remainingTime/60,remainingTime%60);
    }
    public void StartScreen()
    {
        panelsUI[0].SetActive(true);
        panelsUI[1].SetActive(false);
        panelsUI[2].SetActive(false);
        panelsUI[3].SetActive(false);
        foreach (var level in levels)
        {
            level.SetActive(false);
        }
    }
    public void LoseLive()
    {
        if(isTimerRunning)
        {
            remainingLives-=1;
            if (remainingLives >= 0)
            {
                lives.text = string.Format("Lives: {0}",remainingLives);        
            }
            else
            {
                GameOver();
            }
        }
        else
        {
            Debug.Log("Juego en standby");
        }
    }
}
