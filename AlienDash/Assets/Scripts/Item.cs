using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float yOffsetForDeletingObject = 5f;

    Spawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();

        if(gameObject.GetComponent<Booster>() || gameObject.GetComponent<CoinBooster>())
        {
            spawner.addBoosterCount();
        }

        if(gameObject.GetComponent<RainbowBlock>() || gameObject.GetComponent<CoinRainbow>() || gameObject.GetComponent<CoinRainbow2>())
        {
            if(spawner.getRainbowCount() >= spawner.getRainbowLimit())
            {
                Destroy(gameObject);
            }

            else
            {
                spawner.addRainbowCount();
            }
        }

        if(gameObject.GetComponent<TNT>())
        {
            spawner.addTntCount();
        }
    }
    private void Update()
    {
        if(transform.position.y < Camera.main.transform.position.y - yOffsetForDeletingObject)
        {
            spawner.minusCount();

            if(gameObject.GetComponent<Booster>() || gameObject.GetComponent<CoinBooster>())
            {
                spawner.minusBoosterCount();
            }

            if(gameObject.GetComponent<RainbowBlock>() || gameObject.GetComponent<CoinRainbow>() || gameObject.GetComponent<CoinRainbow2>())
            {
                spawner.minusRainbowCount();
            }

            if(gameObject.GetComponent<TNT>())
            {
                spawner.minusTntCount();
            }

            Destroy(gameObject);          
        }
    }
}