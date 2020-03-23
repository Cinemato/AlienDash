using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] GameObject coinVFX;
    [SerializeField] float rotationSpeed = 1f;

    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime * rotationSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(pickUpSound, Camera.main.transform.position, 0.3f);
        GameObject VFX = Instantiate(coinVFX, transform.position, Quaternion.identity);
        Destroy(VFX, 1f);
    }
}
