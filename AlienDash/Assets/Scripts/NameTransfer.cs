using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTransfer : MonoBehaviour
{
    string playerName;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject leaderBoard;
    [SerializeField] GameObject nameExistText;
    [SerializeField] GameObject enterButton;
    [SerializeField] GameObject instructionText;
    [SerializeField] GameObject trophyImage;
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip failSound;
    [SerializeField] int nameCharLimit;



    private void Start()
    {
        PlayerPrefs.SetInt("isInLeaderboard", 1);

        if (PlayerPrefs.GetInt("hasName", 0) == 1)
        {
            switchToLeaderboard();
        }
    }

    private void Update()
    {
        inputField.GetComponent<InputField>().characterLimit = nameCharLimit;
    }

    public void storeName()
    {
        playerName = inputField.GetComponent<InputField>().text;
        Leaderboard.checkNameAvailability(playerName);

        if(PlayerPrefs.GetInt("Available") == 1 && playerName != "")
        {                   
            PlayerPrefs.SetString("playerName", playerName);
            PlayerPrefs.SetInt("hasName", 1);
            
            Leaderboard.addNewHighscore(PlayerPrefs.GetString("playerName", playerName), PlayerPrefs.GetInt("HighScore", 0));
            AudioSource.PlayClipAtPoint(successSound, Camera.main.transform.position, 0.7f);
            switchToLeaderboard();
        }

        else
        {
            nameExistText.SetActive(true);
            AudioSource.PlayClipAtPoint(failSound, Camera.main.transform.position, 0.7f);
            return;
        }
            
     
    }

    void switchToLeaderboard()
    {
        trophyImage.SetActive(true);
        leaderBoard.SetActive(true);
        nameExistText.SetActive(false);
        inputField.SetActive(false);       
        enterButton.SetActive(false) ;
        instructionText.SetActive(false);       
    }
}
