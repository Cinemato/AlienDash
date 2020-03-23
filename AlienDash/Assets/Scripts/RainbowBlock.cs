using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBlock : MonoBehaviour
{
    [SerializeField] int fuelAmount = 75;
    [SerializeField] GameObject vfx;
    [SerializeField] AudioClip pickUpSound;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Jetpack>())
        {
            AudioSource.PlayClipAtPoint(pickUpSound, Camera.main.transform.position, 0.5f);
            Jetpack player = collision.GetComponent<Jetpack>();
            player.addFuel(fuelAmount);
            GameObject vfx1 = Instantiate(vfx, transform.position, Quaternion.identity);
            Destroy(vfx1, 1f);
        }
    }
}
