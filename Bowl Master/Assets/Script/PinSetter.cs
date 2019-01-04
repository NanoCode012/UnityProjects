using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text StandingPinText;
    public GameObject PinSet;

    [SerializeField] private int lastStandingCount = -1;
    [SerializeField] private int currentStandingCount = 10;

    private Pin[] pins;
    private Ball ball;
    private ActionMaster actionMaster;
    private Animator animator;

    private float timeSinceLastChange;
    private readonly float timeToWait = 3;

    private bool ballEnteredBox = false;

    // Use this for initialization
    void Start () {
        pins = FindObjectsOfType<Pin>();
        ball = FindObjectOfType<Ball>();

        actionMaster = new ActionMaster();

        animator = GetComponent<Animator>();
	}

    void SetTextDisplay(int count)
    {
        StandingPinText.text = count.ToString();
    }

    private void Update()
    {
        if (ballEnteredBox)
        {
            UpdateStandingCountAndSettle();
        }
    }

    void UpdateStandingCountAndSettle()
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

        int numberOfPinsFallen = currentStandingCount - lastStandingCount;
        currentStandingCount = lastStandingCount;

        ActUponPinsFallen(numberOfPinsFallen);

        lastStandingCount = -1;

        StandingPinText.color = new Color(0, 1, 0);

        ball.Reset();
    }

    private void ActUponPinsFallen(int numberOfPinsFallen)
    {
        ActionMaster.Action action = actionMaster.Bowl(numberOfPinsFallen);
        switch (action)
        {
            case ActionMaster.Action.Tidy:
                animator.SetTrigger("Tidy Trigger");
                break;
            case ActionMaster.Action.Reset:
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("Reset Trigger");
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
