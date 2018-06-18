using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingPinText;

    private Pin[] pins;

    public int Count { get; private set; }

    // Use this for initialization
    void Start () {
        pins = FindObjectsOfType<Pin>();
	}

    void SetTextDisplay(int count)
    {
        standingPinText.text = count.ToString();
    }

    private void Update()
    {
        SetTextDisplay(CountStanding());
    }

    int CountStanding()
    {
        int temp = 0;
        foreach (var pin in pins)
        {
            if (pin.IsStanding()) temp++;
        }
        return temp;
    }
}
