using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] GameObject helpText;
    [SerializeField] GameObject ghostPower;
    [SerializeField] GameObject slowEffect;
    [SerializeField] GameObject boltPower;

    Jetpack player;
    int numberOfEffects = -1;

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

            if(player.getHasBoost())
            {
                boltPower.SetActive(true);
            }

            else
            {
                boltPower.SetActive(false);
            }
        }    
    }

    void helpFalse()
    {
        helpText.SetActive(false);
    }

    public void minusEffect()
    {
        numberOfEffects--;
    }

    public void addEffect()
    {
        numberOfEffects++;
    }

    public int getNumberOfEffects()
    {
        return numberOfEffects;
    }
}


