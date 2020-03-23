using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    Jetpack player;
    bool hasPlayedVFX = false;
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
            StartCoroutine(cameraShake.Shake(0.4f, 0.4f));
            player.setHasFuel(false);
            if (!hasPlayedVFX)
            {
                GameObject VFX = Instantiate(explosionVFX, transform.position, Quaternion.identity);
                hasPlayedVFX = true;
                Destroy(VFX, 3.5f);
            }

            else
                return;
        }
    }
}
