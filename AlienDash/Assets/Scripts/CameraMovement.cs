using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform centerBackground;
    [SerializeField] float offset = 2f;
    Jetpack player;
   

    void Start()
    {
        player = FindObjectOfType<Jetpack>();
    }


    void Update()
    {
        if(player != null)
        {
            if (!player.isGoingDown() || player.getOnGround())
            {
                if (player.transform.position.y > this.transform.position.y - offset)
                {
                    this.transform.position = new Vector3(transform.position.x, player.transform.position.y + offset, transform.position.z);
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
}
