using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] AudioClip loseSound;
    Jetpack Player;  

    bool hasStartedSound;

    private void Start()
    {
        hasStartedSound = false;
        Player = FindObjectOfType<Jetpack>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("hasLost", 1);
            Player.setHasFuel(false);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + Player.getCoins());
          
        
            if (hasStartedSound == false)
            {
                if(gameObject.GetComponent<TNT>())
                {
                    AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position);
                }

                else if(!Player.getHasExploded())
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

 

