using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] GameObject slowVFX;

    Jetpack player;
    private void Start()
    {
        player = FindObjectOfType<Jetpack>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Jetpack>())
        {
            if(!player.getHasGhost())
            {
                AudioSource.PlayClipAtPoint(pickUpSound, Camera.main.transform.position, 0.3f);
                GameObject VFX = Instantiate(slowVFX, transform.position, Quaternion.identity);
                Destroy(VFX, 1f);
            }          
        }
    }
}
