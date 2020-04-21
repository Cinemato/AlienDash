using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerIcon : MonoBehaviour
{
    GameCanvas gameCanvas;

    private void Start()
    {
        gameCanvas = FindObjectOfType<GameCanvas>();
    }


    public void positionIcons()
    {
        if (gameCanvas.getNumberOfEffects() < 1)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(68, GetComponent<RectTransform>().anchoredPosition.y);
        }

        if (gameCanvas.getNumberOfEffects() == 1)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(176, GetComponent<RectTransform>().anchoredPosition.y);
        }

        if(gameCanvas.getNumberOfEffects() == 2)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(284, GetComponent<RectTransform>().anchoredPosition.y);
        }
    }
}
