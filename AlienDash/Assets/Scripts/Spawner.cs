using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Overall Spawner")]
    [SerializeField] GameObject[] prefabs;
    [SerializeField] float spawnDelay = 3f;
    [SerializeField] int count = 0;
    [SerializeField] int itemsPerScreen = 10;
    [SerializeField] float yOffset;

    [Header("Booster")]
    [SerializeField] int boosterCount = 0;
    [SerializeField] int boosterLimit = 2;
    [SerializeField] float boosterSpawnChance = 0.2f;
    [SerializeField] float boosterWithCoinsSpawnChance = 0.1f;

    [Header("Rainbow Dust")]
    [SerializeField] int rainbowCount = 0;
    [SerializeField] int rainbowLimit = 2;
    [SerializeField] float rainbowDustSpawnChance = 0.4f;
    [SerializeField] float rainbowDustWithCoinsSpawnChance = 0.1f;

    [Header("Coin")]
    [SerializeField] float coinSpawnChance = 0.6f;
    [SerializeField] float multipleCoinsSpawnChance = 0.4f;

    [Header("TNT")]
    [SerializeField] int tntCount = 0;
    [SerializeField] int tntLimit = 1;
    [SerializeField] float tntSpawnChance = 0.4f;

    [Header("Ghost")]
    [SerializeField] int ghostCount = 0;
    [SerializeField] int ghostLimit = 1;
    [SerializeField] float ghostSpawnChance = 0.15f;
    
    [Header("Barrier")]
    [SerializeField] int barrierCount = 0;
    [SerializeField] int barrierLimit = 1;
    [SerializeField] float barrierSpawnChance = 0.5f;

    [Header("Slowness")]
    [SerializeField] int slowCount = 0;
    [SerializeField] int slowLimit = 0;
    [SerializeField] float slowSpawnChance = 0.4f;


    Vector3 screenPos;
    Vector3 previousPosition;

    Score score;

    private void Start()
    {
        previousPosition = transform.position;
        InvokeRepeating("spawnPrefab", spawnDelay, spawnDelay);
        score = FindObjectOfType<Score>();
    }


    public void minusCount()
    {
        count--;
    }

    public void minusBoosterCount()
    {
        boosterCount--;
    }

    public void minusRainbowCount()
    {
        rainbowCount--;
    }

    public void minusTntCount()
    {
        tntCount--;
    }

    public void minusGhostCount()
    {
        ghostCount--;
    }

    public void minusBarrierCount()
    {
        barrierCount--;
    }

    public void addRainbowCount()
    {
        rainbowCount++;
    }

    public void addBoosterCount()
    {
        boosterCount++;
    }

    public void addTntCount()
    {
        tntCount++;
    }

    public void addGhostCount()
    {
        ghostCount++;
    }

    public void addBarrierCount()
    {
        barrierCount++;
    }

    public int getRainbowCount()
    {
        return rainbowCount;
    }

    public int getRainbowLimit()
    {
        return rainbowLimit;
    }

    public void addSlowCount()
    {
        slowCount++;
    }

    public void minusSlowCount()
    {
        slowCount--;
    }


    private void Update()
    {
        if(count < 0)
        {
            count = 0;
        }

        if(score != null)
        {

            if(score.getScore() > 35)
            {
                ghostLimit = 1;
            }

            if (score.getScore() >= 150 && score.getScore() < 450)
            {
                tntSpawnChance = 0.6f;
            }

            if(score.getScore() >= 300)
            {
                tntLimit = 2;
            }

            if(score.getScore() >= 75 && score.getScore() < 150)
            {
                slowLimit = 1;
            }

            if(score.getScore() >= 150 && score.getScore() < 300)
            {
                slowSpawnChance = 0.6f;
            }

            if (score.getScore() >= 300 && score.getScore() < 450)
            {
                slowLimit = 2;
            }

            if(score.getScore() >= 450)
            {
                slowLimit = 1;
                tntSpawnChance = 0.8f;
                boosterSpawnChance = 0.4f;
            }
        }      
    }


    void spawn(float minXPos, float maxXPos, float chance, GameObject prefab)
    {
        if (Random.value <= chance)
        {
            if(count < itemsPerScreen)
            {
                Vector3 finalPos;
                float yPos = previousPosition.y + 10;

                if (Random.value <= 0.5)
                {
                    finalPos = new Vector3(Mathf.Clamp(screenPos.x + previousPosition.x, minXPos, maxXPos), yPos, transform.position.z);
                }
                else
                {
                    finalPos = new Vector3(Mathf.Clamp(screenPos.x - previousPosition.x, minXPos, maxXPos), yPos, transform.position.z);
                }

                GameObject stuff = Instantiate(prefab, finalPos, Quaternion.identity);
                if(stuff == null)
                {
                    Debug.Log("NULL!");
                }
                Debug.Log(stuff);
                previousPosition = new Vector3(Mathf.Clamp(stuff.transform.position.x, -2.22f, 2.22f), stuff.transform.position.y - yOffset, stuff.transform.position.z);

                count++;
            }          
        }
    }

    public void spawnPrefab()
    {
        screenPos = Camera.main.ViewportToWorldPoint(new Vector3(Mathf.Clamp(Random.Range(0.1f, 0.7f), -2.22f, 2.22f), Random.Range(1.1f, 2), 10));

        foreach (GameObject thing in prefabs)
        {
            if (count < itemsPerScreen)
            {
                if (thing.GetComponent<Booster>() != null && boosterCount < boosterLimit)
                {
                    spawn(-2.4f, 2.4f, boosterSpawnChance, thing);
                }

                if (thing.GetComponent<CoinBooster>() != null && boosterCount < boosterLimit)
                {
                    spawn(-2.3f, 1.1f, boosterWithCoinsSpawnChance, thing);
                }

                if (thing.GetComponent<Coin>() != null)
                {
                    spawn(-2.4f, 2.4f, coinSpawnChance, thing);
                }

                if (thing.GetComponent<Coins>() != null)
                {
                    spawn(-1.9f, 1.9f, multipleCoinsSpawnChance, thing);
                }

                if (thing.GetComponent<RainbowBlock>() != null && rainbowCount < rainbowLimit)
                {
                    spawn(-2.4f, 2.4f, rainbowDustSpawnChance, thing);
                }

                if (thing.GetComponent<CoinRainbow>() != null && rainbowCount < rainbowLimit)
                {
                    spawn(-1.8f, 1.8f, rainbowDustWithCoinsSpawnChance, thing);
                }

                if (thing.GetComponent<CoinRainbow2>() != null && rainbowCount < rainbowLimit)
                {
                    spawn(-3.8f, -0.04f, multipleCoinsSpawnChance, thing);
                }

                if (thing.GetComponent<TNT>() != null && tntCount < tntLimit)
                {
                    spawn(-2.4f, 2.4f, tntSpawnChance, thing);
                }

                if (thing.GetComponent<Ghost>() != null && ghostCount < ghostLimit)
                {
                    spawn(-2.4f, 2.4f, ghostSpawnChance, thing);
                }

                if(thing.GetComponent<Slow>() != null && slowCount < slowLimit)
                {
                    spawn(-2.4f, 2.4f, slowSpawnChance, thing);
                }


            }

            else
                break;
        }

    }







   // Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.5f, 1), Random.Range(1.1f, 2), 10));
   // Vector2 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0.5f, Screen.width), Random.Range(1.1f, Screen.height)));
   // Instantiate(prefabs[Random.Range(0, prefabs.Length)], screenPosition, Quaternion.identity);
}
