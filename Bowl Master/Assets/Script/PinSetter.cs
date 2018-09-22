using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text StandingPinText;
    public GameObject PinSet;

    [SerializeField] private int lastStandingCount = -1;

    private Pin[] pins;
    private Ball ball;

    private float timeSinceLastChange;
    private readonly float timeToWait = 3;

    private bool ballEnteredBox = false;

    // Use this for initialization
    void Start () {
        pins = FindObjectsOfType<Pin>();
        ball = FindObjectOfType<Ball>();
	}

    void SetTextDisplay(int count)
    {
        StandingPinText.text = count.ToString();
    }

    private void Update()
    {
        if (ballEnteredBox)
        {
            CheckStanding();
        }
    }

    void CheckStanding()
    {
        int standing = CountStanding();
        SetTextDisplay(standing);

        float currentTime = Time.timeSinceLevelLoad;
        if (lastStandingCount != standing)
        {
            timeSinceLastChange = currentTime;
            lastStandingCount = standing;
        }
        else if (timeSinceLastChange + timeToWait <= currentTime)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        ballEnteredBox = false;
        lastStandingCount = -1;

        StandingPinText.color = new Color(0, 1, 0);

        ball.Reset();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            StandingPinText.color = new Color(1, 0, 0);
        }
    }

    int CountStanding()
    {
        int pinStanding = 0;
        foreach (var pin in pins)
        {
            if (pin)
            {
                if (pin.IsStanding()) pinStanding++;
            }
        }

        return pinStanding;
    }

    public void RaisePins()
    {
        foreach(var pin in pins)
        {
            if (pin)
            {
                pin.Raise();
            }
        }
    }

    public void LowerPins()
    {
        foreach (var pin in pins)
        {
            if (pin)
            {
                pin.Lower();
            }
        }
    }

    public void RenewPins()
    {
        Instantiate(PinSet);
    }
}
