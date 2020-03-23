using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    
    public void setFuel(int newFuel)
    {
        slider.value = newFuel;
    }

    public void setMaxFuel(int newMax)
    {
        slider.maxValue = newMax;
        slider.value = newMax;
    }
}
