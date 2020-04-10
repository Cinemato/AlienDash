using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    Jetpack player;
    bool hasExploded = false;
    CameraShake cameraShake;
    [SerializeField] GameObject explosionVFX;

    private void Start()
    {
        player = FindObjectOfType<Jetpack>();
        cameraShake = FindObjectOfType<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Jetpack>())
        {
            if(!player.getHasGhost())
            {
                if (!hasExploded)
                {
                    StartCoroutine(cameraShake.Shake(0.4f, 0.2f));
                    player.setHasFuel(false);
                    GameObject VFX = Instantiate(explosionVFX, transform.position, Quaternion.identity);
                    hasExploded = true;
                    Destroy(VFX, 3.5f);
                }

                else
                    return;
            }
            
        }
    }
}
