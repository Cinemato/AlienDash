using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] GameObject helpText;
    Jetpack player;
    void Start()
    {
        player = FindObjectOfType<Jetpack>();

        if(PlayerPrefs.GetInt("HighScore") < 50)
        {
            helpText.SetActive(true);
        }

        else
        {
            helpFalse();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (player.getIsFlying())
            {
                helpFalse();
            }
        }    
    }

    void helpFalse()
    {
        helpText.SetActive(false);
    }
}
