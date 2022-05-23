using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SliderSaver : MonoBehaviour
{
 //Kitchen sliders and toggle
    public Slider KitchenBrightnessSlider;
    public Slider KitchenTempuratureSlider;
    public Toggle Kitchentoggle; //static
 //Bedroom sliders and toggle
    public Slider BedroomBrightnessSlider;
    public Slider BedroomTempuratureSlider;
    public Toggle Bedroomtoggle; //static

    public Toggle MasterToggle; //static
 //Kitchen Slider Values
    public float KitchenBrightnessSliderValue;
    public float KitchenTempuratureSliderValue;
 //Bedroom Slider Values
    public float BedroomBrightnessSliderValue;
    public float BedroomTempuratureSliderValue;
//Maximum and minimum values for random.range, so there wont be any magic numbers in the code
    private int _maxValue =100;
    private int _minValue =1;


    public void Start()
    {
        //at the start, both on play and when you change back and forth on the scenes, these values will be called.

       
        MasterToggle.onValueChanged.AddListener(OnchangeMaster);

       // KitchenBrightnessSlider.value = PlayerPrefs.GetFloat("saveKitchenBrightnessSlider");
        KitchenTempuratureSlider.value = PlayerPrefs.GetFloat("saveKitchenTempuratureSlider");

        Kitchentoggle.onValueChanged.AddListener(OnchangedKitchen);

        BedroomBrightnessSlider.value = PlayerPrefs.GetFloat("saveBedroomBrightnessSlider");
        BedroomTempuratureSlider.value = PlayerPrefs.GetFloat("saveBedroomTempuratureSlider");

        //this line of code listens for the Changes in the BedroomBrightnessSlider script so it works
        Bedroomtoggle.onValueChanged.AddListener(OnchangedBedroom);

        //these line of code listens for the Changes in the Slider scripts so it will remember theír values and b
        BedroomBrightnessSlider.onValueChanged.AddListener(ChangeBedroomBrightnessSlider);

        BedroomTempuratureSlider.onValueChanged.AddListener(ChangeBedroomTempuratureSlider);

        KitchenBrightnessSlider.onValueChanged.AddListener(ChangeKitchenBrightnessSlider);

        KitchenTempuratureSlider.onValueChanged.AddListener(ChangeKitchenTempuratureSlider);




        //this makes the BrightnessValue the same as the slider.Value, this could probably be deleted and just write BrightnessSlider.value everywhere instead of BrightnessSliderValue and vise versa
        BedroomBrightnessSliderValue = BedroomBrightnessSlider.value;

        KitchenBrightnessSliderValue = KitchenBrightnessSlider.value;



        //KitchenBrightnesssliders gets its value from PlayerPrefs float which is called "saveKitchenBrightnessSlider" 
        KitchenBrightnessSlider.value = PlayerPrefs.GetFloat("saveKitchenBrightnessSlider");

        //if statement that shows that when the sliders value is 0, the togglebutton should be off and if not then the toggle button is on
        if (KitchenBrightnessSliderValue == 0)
        {
            Kitchentoggle.isOn = false;
        }
        else
        {
            Kitchentoggle.isOn = true;
        }

        //BedroomBrightnesssliders gets its value from PlayerPrefs float which is called "saveKitchenBrightnessSlider" 
        BedroomBrightnessSlider.value = PlayerPrefs.GetFloat("saveBedroomBrightnessSlider");
        //if statement that shows that when the sliders value is 0, the togglebutton should be off and if not then the toggle button is on
        if (BedroomBrightnessSliderValue == 0)
        {
            Bedroomtoggle.isOn = false;
        }
        else
        {
            Bedroomtoggle.isOn = true;
        }

    }


    private void Update()
    {
        // checks if the brightness and kitchen slider values is 0, if it is then the togglebutton turns off. if not then the mastertoggle is on
        if (BedroomBrightnessSlider.value == 0 && KitchenBrightnessSlider.value == 0)
        {
           MasterToggle.isOn = false;
        }
        else
        {
            MasterToggle.isOn = true;
        }
    }

    //this private void checks for the Master togglebuttons state and if it changes. 
    private void OnchangeMaster(bool MastertoggleState)
    {
        //if the togglebutton is on, the Bedroom toggle and Kitchen Toggle will go and get the data from the playerprefs
        if (MastertoggleState)
        {
            //if it is equal to 1 then true else false
            // it checks this by using the ShortHand binary if-else statement in C#, and is checking if the togglebutton state is equal to 1, which means on.
            Bedroomtoggle.isOn = PlayerPrefs.GetInt("Bedroomtoggle") == 1;
            Kitchentoggle.isOn = PlayerPrefs.GetInt("Kitchentoggle") == 1;
                                               
        }
        else
        {
            //if it is not on, it will set the integer data from the togglebutton into playerprefs, but it will also check if the togglebutton is already turned off or on
            //it checks this by using the ShortHand binary if-else statement in C#
            PlayerPrefs.SetInt("Bedroomtoggle", Bedroomtoggle.isOn ? 1 : 0);
            PlayerPrefs.SetInt("Kitchentoggle", Kitchentoggle.isOn ? 1 : 0);
            //after it have saved the data it should turn off the different togglebuttons
            Bedroomtoggle.isOn = false;
            Kitchentoggle.isOn = false;
           // MasterToggle.isOn = false;

        }
    }


    //the name of the void is ChangeKitchenbrightnessSlider which have a float called value
    public void ChangeKitchenBrightnessSlider(float value)
    {
        //makes KitchenBrightnessSliderValue equal to the value of the float of ChangeKitchenBrightnessSlider
        KitchenBrightnessSliderValue = value;

        //this code save/sets the kitchenBrightnessSliderValue in playerprefs
        PlayerPrefs.SetFloat("saveKitchenBrightnessSlider", KitchenBrightnessSliderValue);

        //checks if the value of the KitchenBrightnessSliderValue is 0 and if it is the toggle is off else it is on
        if (KitchenBrightnessSliderValue == 0)
        {
            Kitchentoggle.isOn = false;
        }
        else
        {
            Kitchentoggle.isOn = true;
        }
       
    }


    //the name of the void is ChangeBedroombrightnessSlider which have a float called value
        public void ChangeBedroomBrightnessSlider(float value)
    {
        //makes KitchenBrightnessSliderValue equal to the value of the float of ChangeBedroomBrightnessSlider
        BedroomBrightnessSliderValue = value;

        //this code save/sets the BedroomBrightnessSliderValue in playerprefs
        PlayerPrefs.SetFloat("saveBedroomBrightnessSlider", BedroomBrightnessSliderValue);

        //checks if the value of the BedroomBrightnessSliderValue is 0 and if it is the toggle off else it is on
        if (BedroomBrightnessSliderValue == 0)
        {
            Bedroomtoggle.isOn = false;
        }
        else
        {
            Bedroomtoggle.isOn = true;
        }

    }
    public void ChangeKitchenTempuratureSlider(float value)
    {
        //makes KitchenTempuratureSliderValue equal to the value of the float of ChangeBedroomBrightnessSlider
        KitchenTempuratureSliderValue = value;
        //this code save/sets the KitchentempuratureSliderValue in playerprefs
        PlayerPrefs.SetFloat("saveKitchenTempuratureSlider", KitchenTempuratureSliderValue);
    }

    public void ChangeBedroomTempuratureSlider(float value)
    {
        //makes BedroomTempuratureSliderValue equal to the value of the float of ChangeBedroomBrightnessSlider
        BedroomTempuratureSliderValue = value;
        //this code save/sets the BedroomtempuratureSliderValue in playerprefs
        PlayerPrefs.SetFloat("saveBedroomTempuratureSlider", BedroomTempuratureSliderValue);
    }
 
    public void OnchangedKitchen(bool KitchentoggleState)
    {
       //checks the Kitchentogglestate, if the KitchenBrightnessSliders value is 0
        //if it is 0 then when the toggle is being pressed it gives a random value from between the min and max value
        //which is preset to 1-100, if the kitchenbrightnessSliders value is over 0 then it will get the playerprefs and save the value
        if (KitchentoggleState)
        {

            if (KitchenBrightnessSlider.value == 0 && PlayerPrefs.GetFloat("saveKitchenBrightnessSlider") == 0)
            {
                KitchenBrightnessSlider.value = Random.Range(_minValue, _maxValue);
            }
            else
            {
                KitchenBrightnessSlider.value = PlayerPrefs.GetFloat("saveKitchenBrightnessSlider");

            }
        }
        else 
        {
            // KitchenBrightnessSlider.value = PlayerPrefs.SetFloat("saveKitchenBrightnessSlider");
            // KitchenBrightnessSlider.value = 0;
            float KitchenSliderValueTemporary = KitchenBrightnessSlider.value;
            KitchenBrightnessSlider.value = 0;
            PlayerPrefs.SetFloat("saveKitchenBrightnessSlider", KitchenSliderValueTemporary);
        }
    }
    
    public void OnchangedBedroom(bool BedroomtoggleState)
    {
        //checks the Bedroomtogglestate, if the BedroomBrightnessSliders value is 0
        //if it is 0 then when the toggle is being pressed it gives a random value from between the min and max value
        //which is preset to 1-100, if the BedroombrightnessSliders value is over 0 then it will get the playerprefs and save the value
        //Bool paremeter = BedroomtoggleState is in its own scope which means no other paremeter can be called here
        if (BedroomtoggleState)
        {

            if (BedroomBrightnessSlider.value == 0 && PlayerPrefs.GetFloat("saveBedroomBrightnessSlider") == 0)
            {
                BedroomBrightnessSlider.value = Random.Range(_minValue, _maxValue);
            }
            else
            {
                BedroomBrightnessSlider.value = PlayerPrefs.GetFloat("saveBedroomBrightnessSlider");
            }
        }
        else
        {
            // KitchenBrightnessSlider.value = PlayerPrefs.SetFloat("saveKitchenBrightnessSlider");
            // KitchenBrightnessSlider.value = 0;
            float BedroomSliderValueTemporary = BedroomBrightnessSlider.value;
            BedroomBrightnessSlider.value = 0;
            PlayerPrefs.SetFloat("saveBedroomBrightnessSlider", BedroomSliderValueTemporary);


        }
    }

}
