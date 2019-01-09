using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text StandingPinText;
    public GameObject PinSet;
    public bool BallLeftBox { get; set; }

    [SerializeField] private int lastStandingCount = -1;
    [SerializeField] private int currentStandingCount = 10;

    private Pin[] pins;
    private Ball ball;
    private Animator animator;
    private readonly ActionMaster actionMaster = new ActionMaster();

    private float timeSinceLastChange;
    private const float TimeToWait = 3;


    // Use this for initialization
    private void Start () {
        pins = FindObjectsOfType<Pin>();
        ball = FindObjectOfType<Ball>();

        animator = GetComponent<Animator>();
	}

    private void SetTextDisplay(int count)
    {
        StandingPinText.text = count.ToString();
    }

    private void Update()
    {
        if (BallLeftBox)
        {
            StandingPinText.color = new Color(1, 0, 0);
            UpdateStandingCountAndSettle();
        }
    }

    private void UpdateStandingCountAndSettle()
    {
        var standing = CountStanding();
        SetTextDisplay(standing);

        var currentTime = Time.timeSinceLevelLoad;
        if (lastStandingCount != standing)
        {
            timeSinceLastChange = currentTime;
            lastStandingCount = standing;
        }
        else if (timeSinceLastChange + TimeToWait <= currentTime)
        {
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled()
    {
        BallLeftBox = false;

        var numberOfPinsFallen = currentStandingCount - lastStandingCount;
        currentStandingCount = lastStandingCount;

        ActUponPinsFallen(numberOfPinsFallen);

        lastStandingCount = -1;

        StandingPinText.color = new Color(0, 1, 0);

        ball.Reset();
    }

    private void ActUponPinsFallen(int numberOfPinsFallen)
    {
        var action = actionMaster.Bowl(numberOfPinsFallen);
        switch (action)
        {
            case ActionMaster.Action.Tidy:
                animator.SetTrigger("Tidy Trigger");
                break;
            case ActionMaster.Action.Reset:
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("Reset Trigger");
                break;
            case ActionMaster.Action.Null:
                break;
            case ActionMaster.Action.EndGame:
                break;
            default:
                throw new UnityException("Cannot handle other cases yet");
                break;
        }
    }

    private void PinResetOrientation()
    {
        foreach (var pin in pins)
        {
            if (pin && pin.IsStanding())
            {
                pin.Reset();
            }
        }
    }

    private int CountStanding()
    {
        var pinStanding = 0;

        pins = FindObjectsOfType<Pin>();
        foreach (var pin in pins)
        {
            if (pin && pin.IsStanding())
            {
                pinStanding++;
            }
        }

        return pinStanding;
    }

    public void RaisePins()
    { 
        PinResetOrientation();
        foreach (var pin in pins)
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

        currentStandingCount = 10;
        SetTextDisplay(currentStandingCount);
    }
}
