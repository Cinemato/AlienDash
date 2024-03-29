﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AdsManager ads;
    
    [SerializeField] AudioClip selectSound;
    [SerializeField] GameObject adsButton;


    private void Start()
    {
        ads = FindObjectOfType<AdsManager>();
        purchaseCheck();
    }

    public void startGame()
    {
        if(ads != null)
        {
            ads.LoadLoadInterstitialAd();
            ads.ShowInterstitialAd();
        }       
        PlayerPrefs.SetInt("hasLost", 0);
        PlayerPrefs.SetInt("PlayAgain", 1);
        SceneManager.LoadScene(1);     
    }

    public void mainMenu()
    {
        PlayerPrefs.SetInt("isInLeaderboard", 0);
        PlayerPrefs.SetInt("hasLost", 0);

        if (PlayerPrefs.GetInt("hasName", 0) == 1)
        {
            Leaderboard.addNewHighscore(PlayerPrefs.GetString("playerName"), PlayerPrefs.GetInt("HighScore"));
        }

        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);

        SceneManager.LoadScene(0);

        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void leaderboard()
    {
        PlayerPrefs.SetInt("openedLB", 0);
        SceneManager.LoadScene(2);
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
    }

    public void infoBoard()
    {
        SceneManager.LoadScene(3);
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
        PlayerPrefs.SetInt("newPlayer", 1);
    }

    public void playAgain()
    {
        if (ads != null)
        {
            ads.LoadLoadInterstitialAd();
            ads.ShowInterstitialAd();
        }

        PlayerPrefs.SetInt("hasLost", 0);
        PlayerPrefs.SetInt("PlayAgain", 0);
        SceneManager.LoadScene(1);
    }

    public void purchaseCheck()
    {
        if (PlayerPrefs.GetInt("NoAds", 0) == 1)
        {
            adsButton.SetActive(false);
        }
    }
}
