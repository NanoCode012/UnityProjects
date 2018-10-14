using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Pin>())
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
