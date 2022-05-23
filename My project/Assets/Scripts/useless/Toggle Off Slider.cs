using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOffSlider : MonoBehaviour
{

    public Slider slider;
    public Toggle toggle;

    //public void Toggle_Changed(bool newValue)
    //{
    //   slider.interactable = newValue;
    //}

    public void DisableSlider()
    {
        if (slider != null)
        {
            toggle.isOn = true;

        }
        else
        {
            toggle.isOn = false;

        }
    }

    public void Awake()
    {

        if (slider != null)
        {
            toggle.isOn = false;

        }
        else
        {
            toggle.isOn = true;

        }
    }
}


