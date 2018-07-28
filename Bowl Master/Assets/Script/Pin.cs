using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    //A small calculation to account for rounding errors etc
    private const float epsilon = 0.01f;

    //The maximum angle from the vertical in which it is safe to be called 'Standing'
    private readonly float standingThresholdAngle = 5f + epsilon;

    public bool IsStanding()
    {
        float currentXRotation = Mathf.Abs(transform.eulerAngles.x);
        float currentZRotation = Mathf.Abs(transform.eulerAngles.z);

        return (((currentXRotation <= standingThresholdAngle) || (360 - standingThresholdAngle <= currentXRotation && currentXRotation <= 360 + standingThresholdAngle))
            && ((currentZRotation <= standingThresholdAngle) || (360 - standingThresholdAngle <= currentZRotation && currentZRotation <= 360 + standingThresholdAngle)));
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PinSetter>())
        {
            Destroy(gameObject);
        }
    }
}
