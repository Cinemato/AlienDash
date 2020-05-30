using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform centerBackground;
    [SerializeField] float offset = 2f;
    Jetpack player;
    float timeTilStart = 0.7f;
   

    void Start()
    {
        player = FindObjectOfType<Jetpack>();
    }


    void Update()
    {
        timeTilStart -= Time.deltaTime;

        if(player != null)
        {
            if (!player.isGoingDown() || player.getOnGround())
            {
                if (player.transform.position.y > this.transform.position.y - offset)
                {
                    Vector3 newPos = new Vector3(transform.position.x, player.transform.position.y + offset, transform.position.z);

                    if (timeTilStart > 0 && PlayerPrefs.GetInt("PlayAgain", 1) == 1) // True = 0, False = 1
                    {
                        this.transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime);
                    }

                    else
                    {
                        this.transform.position = newPos;
                    }                                  
                }

                moveBackground();
            }
        }     
    }

    void moveBackground()
    {
        if (transform.position.y >= centerBackground.transform.position.y + 10.24F)
        {
            centerBackground.position = new Vector2(centerBackground.position.x, transform.position.y + 10.24f);
        }
        else if (transform.position.y <= centerBackground.transform.position.y - 10.24F)
        {
            centerBackground.position = new Vector2(centerBackground.position.x, transform.position.y - 10.24f);
        }
    }

    public float getTimer()
    {
        return timeTilStart;
    }
}
