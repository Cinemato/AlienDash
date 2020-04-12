using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintShower : MonoBehaviour
{
    [SerializeField] GameObject clickHereText;
    private void Update()
    {
        if(PlayerPrefs.GetInt("newPlayer", 0) == 1) //0 = True, 1 = False
        {
            clickHereText.SetActive(false);
        }
    }
}
