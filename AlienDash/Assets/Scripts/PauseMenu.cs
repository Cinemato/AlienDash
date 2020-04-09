using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] AudioClip selectSound;


    public void resume()
    {
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    public void pause()
    {
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);

        GameIsPaused = true;

        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (FindObjectOfType<LoseScore>())
        {
            pauseButton.SetActive(false);
        }
    }
}
