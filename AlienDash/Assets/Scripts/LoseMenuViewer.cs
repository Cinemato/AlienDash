using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenuViewer : MonoBehaviour
{
    [SerializeField] GameObject newScoreUI;
    [SerializeField] GameObject loseMenuUI;
    Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("hasLost", 0) == 1)
        {
            StartCoroutine(waitBeforeLose());
            if (score.getScore() > PlayerPrefs.GetInt("HighScore", 0))
            {
                StartCoroutine(waitBeforeNewScore());
                PlayerPrefs.SetInt("HighScore", score.getScore());
            }
        }

    }

    IEnumerator waitBeforeLose()
    {
        yield return new WaitForSeconds(0.3f);
        loseMenuUI.SetActive(true);
    }

    IEnumerator waitBeforeNewScore()
    {
        yield return new WaitForSeconds(0.3f);
        newScoreUI.SetActive(true);
    }
}
