using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score = 0;
    Jetpack player;
    TextMeshProUGUI text;
    [SerializeField] int scoreAddAmount = 1;
    [SerializeField] float timer = 5f;
    [SerializeField] GameObject doubleScoreUI;
    float startTime;
    int originalScoreAddAmount;

    void Start()
    {
        originalScoreAddAmount = scoreAddAmount;
        startTime = timer;
        text = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Jetpack>();
    }

    
    void Update()
    {
        timer -= Time.deltaTime;
        text.text = score.ToString();
        if(player != null)
        {
            if (player.getIsFlying() && timer <= 0)
            {
                addScore(scoreAddAmount);
                timer = startTime;
            }

            if (player.getHasBoost())
            {
                scoreAddAmount = 4;
                doubleScoreUI.SetActive(true);
            }

            if (!player.getHasBoost())
            {
                scoreAddAmount = originalScoreAddAmount;
                doubleScoreUI.SetActive(false);
            }
        }
    }

    public void addScore(int amount)
    {
        score += amount;
    }

    public int getScore()
    {
        return score;
    }

    
}
