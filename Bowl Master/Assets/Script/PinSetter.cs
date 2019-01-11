using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public GameObject PinSet;

    private Pin[] pins; 
    private Animator animator;
    private PinCounter pinCounter;
    
    // Use this for initialization
    private void Start ()
    {
        pins = FindObjectsOfType<Pin>();
        animator = GetComponent<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();
    }

    public void DoAction(ActionMaster.Action action)
    {
        pins = FindObjectsOfType<Pin>();

        switch (action)
        {
            case ActionMaster.Action.Tidy:
                animator.SetTrigger("Tidy Trigger");
                break;
            case ActionMaster.Action.Reset:
            case ActionMaster.Action.EndTurn:
                animator.SetTrigger("Reset Trigger");
                pinCounter.RenewPinCount();
                break;
            default:
                throw new UnityException("Cannot handle other cases yet");
                break;
        }
    }

    public void RaisePins()
    { 
        foreach (var pin in pins)
        {
            if (pin)
            {
                pin.RaiseIfStanding();
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
