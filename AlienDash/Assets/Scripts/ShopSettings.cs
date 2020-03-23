using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShopSettings : MonoBehaviour
{
    Jetpack player;
    [SerializeField] Sprite[] skins;

    private void Update()
    {
       player = FindObjectOfType<Jetpack>();

       if(player != null)
       {
           player.GetComponent<SpriteRenderer>().sprite = skins[PlayerPrefs.GetInt("usedSkin", 0)];
       }
           
    }

}
