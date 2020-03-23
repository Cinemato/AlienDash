using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AdsManager ads;
    [SerializeField] AudioClip selectSound;

    private void Start()
    {
        ads = FindObjectOfType<AdsManager>();
    }

    public void startGame()
    {
        if(ads != null)
        {
            ads.AdShower();
        }       
        PlayerPrefs.SetInt("hasLost", 0);
        SceneManager.LoadScene(1);
    }

    public void mainMenu()
    {
        PlayerPrefs.SetInt("isInLeaderboard", 0);
        PlayerPrefs.SetInt("hasLost", 0);
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
        SceneManager.LoadScene(0);
    }

    public void leaderboard()
    {
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
        SceneManager.LoadScene(2);
    }


}
