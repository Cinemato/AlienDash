using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBarrier : MonoBehaviour
{
    Jetpack player;

    private void Start()
    {
        player = FindObjectOfType<Jetpack>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Jetpack>() && !player.getIsFlying())
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }




}
