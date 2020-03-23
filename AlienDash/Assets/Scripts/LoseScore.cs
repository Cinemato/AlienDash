using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseScore : MonoBehaviour
{
    Score score;
    Jetpack player;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI coinsText;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Jetpack>();
        score = FindObjectOfType<Score>();
        scoreText.text = score.getScore().ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        if(player != null)
        {
            coinsText.text = player.getCoins().ToString();
        }        
    }
}
