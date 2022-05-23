using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowSliderValue : MonoBehaviour
{
    [SerializeField] private Slider Kitchenslider;
    [SerializeField] private TextMeshProUGUI KitchenSliderValueText;

    [SerializeField] private Slider Bedroomslider;
    [SerializeField] private TextMeshProUGUI BedroomSliderValueText;
    void Start()
    {
        //setting the Kitchen value text = to the Kitchensliders value does so the text shows the slider value all the time 
        //if this code wasnt made it would only show the new value and not the start value before any changes was made
        KitchenSliderValueText.text = Kitchenslider.value.ToString();
        //Kitchenslider listens for changes and when there is changes, it changes the value and the text
        Kitchenslider.onValueChanged.AddListener((newSliderValue) =>
        {
           KitchenSliderValueText.text = newSliderValue.ToString("");
        });

        //setting the bedroom value text = to the bedroomssliders value does so the text shows the slider value all the time 
        //if this code wasnt made it would only show the new value and not the start value before any changes was made
        BedroomSliderValueText.text = Bedroomslider.value.ToString();
        //bedroomslider listens for changes and when there is changes, it changes the value and the text
        Bedroomslider.onValueChanged.AddListener((newSliderValue) =>
        {
            BedroomSliderValueText.text = newSliderValue.ToString("");
        });
    }
}
