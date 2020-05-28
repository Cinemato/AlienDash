using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintShower : MonoBehaviour
{
    [SerializeField] GameObject clickHereText;
    [SerializeField] GameObject addScoreText;
    private void Update()
    {
        if(PlayerPrefs.GetInt("newPlayer", 0) == 1) //0 = True, 1 = False
        {
            clickHereText.SetActive(false);
        }

        if (PlayerPrefs.GetInt("hasName", 0) == 0 && PlayerPrefs.GetInt("HighScore", 0) > 0)
        {
            addScoreText.SetActive(true);
        }

        if(PlayerPrefs.GetInt("openedLB", 1) == 0 || PlayerPrefs.GetInt("hasName", 0) == 1)
        {
            addScoreText.SetActive(false);
        }
    }
}
