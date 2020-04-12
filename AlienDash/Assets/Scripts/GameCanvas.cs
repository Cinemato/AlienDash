using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] GameObject helpText;
    [SerializeField] GameObject ghostPower;
    [SerializeField] GameObject slowEffect;

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

            if(player.getHasGhost())
            {              
                if (player.getHasSlow())
                {
                    ghostPower.GetComponent<RectTransform>().anchoredPosition = new Vector2(176, ghostPower.GetComponent<RectTransform>().anchoredPosition.y);
                }

                else
                {
                    ghostPower.GetComponent<RectTransform>().anchoredPosition = new Vector2(68, ghostPower.GetComponent<RectTransform>().anchoredPosition.y);
                }

                ghostPower.SetActive(true);
            }

            else
            {
                ghostPower.SetActive(false);
            }

            if(player.getHasSlow())
            {              
                slowEffect.SetActive(true);
            }

            else
            {
                slowEffect.SetActive(false);
            }
        }    
    }

    void helpFalse()
    {
        helpText.SetActive(false);
    }
}
