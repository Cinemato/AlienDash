using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skins : MonoBehaviour
{
    SpriteRenderer renderer;
    Player player;
    int currentSkinIndex;

    [SerializeField] Sprite[] skins;
    [SerializeField] GameObject buyUI;
    [SerializeField] GameObject playUI;
    [SerializeField] GameObject rightSPButton;
    [SerializeField] GameObject leftSPButton;
    [SerializeField] TextMeshProUGUI rightSPText;
    [SerializeField] TextMeshProUGUI leftSPText;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] GameObject madeByText; 
    [SerializeField] GameObject skinPackText;
    [SerializeField] int[] skinPrices; //Prices for skins depending on their index. So price if skins[0] is skinPrices [0].
    [SerializeField] AudioClip selectSound;
    [SerializeField] AudioClip failSound;
    [SerializeField] AudioClip buySound;
    int[] hasBought; // Checks if a skin is bought or not. 1 for true, 0 for false.

    void Start()
    {
        currentSkinIndex = PlayerPrefs.GetInt("usedSkin", 0);

        hasBought = new int[skins.Length];
        hasBought[0] = 1;

        for(int i = 1; i < hasBought.Length; i++)
        {
            hasBought[i] = PlayerPrefs.GetInt("hasBought" + i, 0);
        }

        player = FindObjectOfType<Player>();
        renderer = player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        priceText.text = skinPrices[currentSkinIndex].ToString();
        renderer.sprite = skins[currentSkinIndex];

        if (currentSkinIndex > 21)
        {
            if (skinPackText.GetComponent<TextMeshProUGUI>())
            {
                skinPackText.SetActive(true);
                if(currentSkinIndex > 28)
                {
                    skinPackText.GetComponent<TextMeshProUGUI>().text = "Skin Pack 2";
                }

                else
                    skinPackText.GetComponent<TextMeshProUGUI>().text = "Skin Pack 1";
            }
        }

        else
            skinPackText.SetActive(false);


        if (currentSkinIndex > 30 && currentSkinIndex < 35)  //Temporary Addition *** Better System Soon
        {
            madeByText.SetActive(true);
        }

        else
            madeByText.SetActive(false);

        if(currentSkinIndex > 0 && currentSkinIndex < 29)
        {
            rightSPButton.SetActive(true);
        }

        else
        {
            rightSPButton.SetActive(false);
        }

        if(currentSkinIndex > 7)
        {
            leftSPButton.SetActive(true);
        }

        else
        {
            leftSPButton.SetActive(false);
        }

        if(currentSkinIndex < 22)
        {
            rightSPText.text = "SP1";
        }

        else if(currentSkinIndex >= 22)
        {
            rightSPText.text = "SP2";
        }

        if(currentSkinIndex < 29)
        {
            leftSPText.text = "Start";
        }

        else if(currentSkinIndex >= 29)
        {
            leftSPText.text = "SP1";
        }
    }

    private void FixedUpdate()
    {        
        if(hasBought[currentSkinIndex] == 1)
        {
            PlayerPrefs.SetInt("usedSkin", currentSkinIndex);
        }        
    }


    public void rightMouseButton()
    {
        currentSkinIndex++;
        if(currentSkinIndex >= skins.Length)
        {
            currentSkinIndex = 0;
        }

        checkIfBought();

        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
    }

    public void leftMouseButton()
    {
        currentSkinIndex--;
        if(currentSkinIndex < 0)
        {
            currentSkinIndex = skins.Length - 1;
        }

        checkIfBought();

        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
    }

    void bought()
    {
        buyUI.SetActive(false);
        playUI.SetActive(true);
    }

    void notBought()
    {
        buyUI.SetActive(true);
        playUI.SetActive(false);
    }

    public void buy()
    {
        if(skinPrices[currentSkinIndex] <= PlayerPrefs.GetInt("Coins"))
        {
            hasBought[currentSkinIndex] = 1;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - skinPrices[currentSkinIndex]);
            AudioSource.PlayClipAtPoint(buySound, Camera.main.transform.position, 0.7f);
            PlayerPrefs.SetInt("BoolLength", hasBought.Length);

            for(int i = 0; i < hasBought.Length; i++)
            {
                PlayerPrefs.SetInt("hasBought" + i, hasBought[i] == 1 ? 1 : 0);
            }

            bought();
        }

        else
        {
            AudioSource.PlayClipAtPoint(failSound, Camera.main.transform.position, 0.7f);
        }
    }

    public void teleportForward()
    {
        if(currentSkinIndex < 22)
        {
            currentSkinIndex = 22;
            checkIfBought();
        }

        else if(currentSkinIndex >= 22 && currentSkinIndex < 29)
        {
            currentSkinIndex = 29;
            checkIfBought();
        }

        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
    }
    
    public void teleportBackward()
    {
        if(currentSkinIndex < 29)
        {
            currentSkinIndex = 0;
            checkIfBought();
        }

        else if(currentSkinIndex >= 29)
        {
            currentSkinIndex = 22;
            checkIfBought();
        }

        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
    }

    private void checkIfBought()
    {
        if (hasBought[currentSkinIndex] == 1)
        {
            bought();
        }

        else if (hasBought[currentSkinIndex] <= 0)
        {
            notBought();
        }
    }

}
