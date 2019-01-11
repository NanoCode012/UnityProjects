using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
    public Text StandingPinText;

    private GameController gameController;

    [SerializeField] private int lastStandingCount = -1;
    [SerializeField] private int currentStandingCount = 10;

    private float timeSinceLastChange;
    private const float TimeToWait = 3;
    private bool ballLeftBox = false;

    // Use this for initialization
    void Start ()
    {
        gameController = FindObjectOfType<GameController>();

        StandingPinText.color = new Color(0, 1, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (ballLeftBox)
        {
            SetPinFall();
        }
    }

    public void SetPinFall()
    {
        int pinFall = CountStanding();
        SetTextDisplay(pinFall);

        StandingPinText.color = new Color(1, 0, 1);

        var currentTime = Time.timeSinceLevelLoad;
        if (lastStandingCount != pinFall)
        {
            timeSinceLastChange = currentTime;
            lastStandingCount = pinFall;
        }
        else if (timeSinceLastChange + TimeToWait <= currentTime)
        {
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled()
    {
        ballLeftBox = false;
        StandingPinText.color = new Color(0, 1, 0);

        var numberOfPinsFallen = currentStandingCount - lastStandingCount;
        currentStandingCount = lastStandingCount;

        gameController.Bowl(numberOfPinsFallen);

        lastStandingCount = -1;
    }

    private void SetTextDisplay(int count)
    {
        StandingPinText.text = count.ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            ballLeftBox = true;
        }
    }

    private int CountStanding()
    {
        var pinStanding = 0;

        var pins = FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            if (pin && pin.IsStanding())
            {
                pinStanding++;
            }
        }

        return pinStanding;
    }

    public void RenewPinCount()
    {
        currentStandingCount = 10;
        SetTextDisplay(currentStandingCount);
    }
}
