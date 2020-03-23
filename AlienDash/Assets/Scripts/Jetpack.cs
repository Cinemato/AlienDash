using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    Rigidbody2D rigidBody;
    [SerializeField] float jetpackPower = 5f;
    [SerializeField] float fallSpeed = 4f;
    [SerializeField] GameObject firePrefab;
    [SerializeField] float _anglesPerSecond = 90;
    [SerializeField] float rotationSpeed = 3f;
    [SerializeField] int fuel = 100;
    [SerializeField] int maxFuel = 100;
    [SerializeField] float boostPower = 10f;
    [SerializeField] float boostTime = 1f; 

    int coinsEarned = 0;
    Quaternion originalRotation;
    Quaternion newRotation;
    FuelSlider fuelSlider;
    Spawner spawner;

    float originalSpeed;
    float currentYPosition;


    bool hasBoost = false;
    bool isFlying;
    bool onGround = true;
    bool hasFuel = true;
    bool lost = false;
    bool hasExploded = false;

    private void Start()
    {
        newRotation = transform.rotation;
        coinsEarned = 0;
        hasFuel = true;
        spawner = FindObjectOfType<Spawner>();
        fuelSlider = GetComponent<FuelSlider>();
        fuel = maxFuel;
        currentYPosition = transform.position.y;
        originalSpeed = jetpackPower;
        originalRotation = transform.rotation;
        isFlying = false;
        firePrefab.SetActive(false);
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        fuelSlider.setFuel(fuel);

        if ((Input.touchCount > 0 || Input.GetButton("Jump")) && hasFuel)
        {
            fuel -= 1;
            isFlying = true;
            firePrefab.SetActive(true);
            transform.rotation = newRotation;
        }
        else
        {
            Fall();
        }

        if (onGround)
        {
            if (!isFlying)
            {
                firePrefab.SetActive(false);
                transform.rotation = originalRotation;
                rigidBody.AddForce(new Vector2(0f, 0f), ForceMode2D.Force);
            }
        }

        if (fuel <= 0)
        {
            hasFuel = false;
        }

        if (fuel > 0 && !lost)
        {
            hasFuel = true;
        }

        if (fuel > maxFuel)
        {
            fuel = maxFuel;
        }
    }

    IEnumerator BoostTime()
    {
        yield return new WaitForSeconds(boostTime);
        hasBoost = false;
        setOrginalSpeed();
    }

    public bool isGoingDown()
    {
        if (transform.position.y > currentYPosition)
        {
            currentYPosition = transform.position.y;
            return false;
        }

        if (transform.position.y < currentYPosition)
        {
            currentYPosition = transform.position.y;
            return true;
        }

        return true;
    }

    private void FixedUpdate()
    {
        if (isFlying)
        {
            transform.position += transform.up * Time.deltaTime * jetpackPower;
            rigidBody.velocity = new Vector2(0f, jetpackPower * Time.deltaTime);
            onGround = false;
        }
        else if (!isFlying && !onGround)
        {
            rigidBody.AddForce(new Vector2(0f, -fallSpeed), ForceMode2D.Force);
            Vector3 rotation = transform.localEulerAngles;
            rotation.z += Time.deltaTime * _anglesPerSecond * rotationSpeed;
            transform.localEulerAngles = rotation;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Booster>())
        {
            if (!hasBoost)
            {
                addSpeed(boostPower);
                hasBoost = true;
                StartCoroutine(BoostTime());
            }

            if (collision.gameObject.tag == "Booster")
            {
                spawner.minusCount();
                spawner.minusBoosterCount();
            }

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.GetComponent<Coin>())
        {
            if (collision.gameObject.tag == "Coin")
            {
                spawner.minusCount();
            }

            coinsEarned++;

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.GetComponent<RainbowBlock>())
        {
            if (collision.gameObject.tag == "Rainbow")
            {
                spawner.minusCount();
                spawner.minusRainbowCount();
            }

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.GetComponent<LoseCollider>())
        {
            lost = true;
        }

        if(collision.gameObject.GetComponent<TNT>())
        {
            collision.gameObject.GetComponent<Renderer>().enabled = false;
            hasExploded = true;
            Destroy(collision.gameObject, 3.5f);
        }
    }

    public bool getHasBoost()
    {
        return hasBoost;
    }

    void Fall()
    {
        isFlying = false;
        firePrefab.SetActive(false);
        newRotation = transform.rotation;
    }

    public void addFuel(int amount)
    {
        fuel += amount;
    }

    public void addSpeed(float amount)
    {
        jetpackPower += amount;
    }

    public void removeSpeed(float amount)
    {
        jetpackPower -= amount;
    }

    public int getFuel()
    {
        return fuel;
    }

    public int getMaxFuel()
    {
        return maxFuel;
    }

    public void setOrginalSpeed()
    {
        jetpackPower = originalSpeed;
    }

    public bool getIsFlying()
    {
        return isFlying;
    }

    public bool getOnGround()
    {
        return onGround;
    }

    public void setHasBoost(bool hasBoost)
    {
        this.hasBoost = hasBoost;
    }

    public void setHasFuel(bool fuel)
    {
        hasFuel = fuel;
    }

    public int getCoins()
    {
        return coinsEarned;
    }

    public bool getHasExploded()
    {
        return hasExploded;
    }
}


