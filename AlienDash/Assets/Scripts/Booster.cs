using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] GameObject boosterVFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickUpSound, Camera.main.transform.position, 0.5f);
            GameObject vfx = Instantiate(boosterVFX, transform.position, Quaternion.identity);
            Destroy(vfx, 1f);
        }
    }
}