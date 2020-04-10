using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] GameObject ghostVFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Jetpack>())
        {
            AudioSource.PlayClipAtPoint(pickUpSound, Camera.main.transform.position, 0.5f);
            GameObject VFX = Instantiate(ghostVFX, transform.position, Quaternion.identity);
            Destroy(VFX, 1f);
        }
    }
}
