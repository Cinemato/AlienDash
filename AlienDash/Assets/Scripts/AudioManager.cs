using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sprite soundImage;
    [SerializeField] Sprite mutedSoundImage;

    [SerializeField] GameObject muteButton;


    private void Update()
    {
        if (PlayerPrefs.GetInt("muted") == 0)
        {
            muteButton.GetComponent<Image>().sprite = mutedSoundImage;
            AudioListener.volume = 0;
        }

        else
        {
            muteButton.GetComponent<Image>().sprite = soundImage;
            AudioListener.volume = 1;
        }
    }

    public void toggleSound()
    {
        if(PlayerPrefs.GetInt("muted", 0) == 0) 
        {
            PlayerPrefs.SetInt("muted", 1);
        }

        else
        {
            PlayerPrefs.SetInt("muted", 0);
        }
    }



}
