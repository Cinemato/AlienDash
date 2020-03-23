using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdsManager : MonoBehaviour
{
    private string adid = "3501005";
    private string videoad = "video";

    int pressCount = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Monetization.Initialize(adid, true);
    }

    public void AdShower()
    {
        if (PlayerPrefs.GetInt("NoAds", 0) == 0)
        {
            if (pressCount >= 2)
            {
                if (Monetization.IsReady(videoad))
                {
                    ShowAdPlacementContent ad = null;
                    ad = Monetization.GetPlacementContent(videoad) as ShowAdPlacementContent;
                    if (ad != null)
                    {
                        ad.Show();
                    }

                    pressCount = 0;
                }
            }

            else
                pressCount++;
        }

        else
            return;

    }
}