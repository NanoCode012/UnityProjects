using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

	public void ResetData()
    {
        PlayerPrefsManager.SetDefault();
    }
}
