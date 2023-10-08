using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] AudioClip loseSound;
    Jetpack player;

    bool hasStartedSound;

    private void Start()
    {
        hasStartedSound = false;
        player = FindObjectOfType<Jetpack>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && PlayerPrefs.GetInt("hasLost", 0) == 0)
        {
            if(gameObject.GetComponent<TNT>() && player.getHasGhost())
            {
                return;
            }

            else
            {
                PlayerPrefs.SetInt("hasLost", 1);
                player.setHasFuel(false);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + player.getCoins());

                if (hasStartedSound == false)
                {
                    if (gameObject.GetComponent<TNT>())
                    {
                        AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position);
                    }

                    else if (!player.getHasExploded())
                    {
                        AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position, 0.4f);
                    }

                    hasStartedSound = true;

                    if (PlayerPrefs.GetInt("hasName", 0) == 1)
                    {
                        Leaderboard.addNewHighscore(PlayerPrefs.GetString("playerName"), PlayerPrefs.GetInt("HighScore"));
                    }
                }
            }                        
        }              
    }
}

 

