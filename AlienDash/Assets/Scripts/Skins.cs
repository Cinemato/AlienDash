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

        if(hasBought[currentSkinIndex] == 1)
        {
            bought();
        }

        else if(hasBought[currentSkinIndex] <= 0)
        {
            notBought();
        }

        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
    }

    public void leftMouseButton()
    {
        currentSkinIndex--;
        if(currentSkinIndex < 0)
        {
            currentSkinIndex = skins.Length - 1;
        }

        if (hasBought[currentSkinIndex] == 1)
        {
            bought();
        }

        else if (hasBought[currentSkinIndex] <= 0)
        {
            notBought();
        }

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

    
    

}
