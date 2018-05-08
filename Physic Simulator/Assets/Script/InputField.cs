using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour {

    public Slider slider;
    public Text textChildDisplayValue;

	public void SetSliderValue(string num)
    {
        if (!String.IsNullOrEmpty(num))
        {
			slider.value = Convert.ToInt32(num);
        }
    }

    public void ShowSliderValue()
    {
        textChildDisplayValue.text = slider.value.ToString();
    }
}
