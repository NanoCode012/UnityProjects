using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAwake : MonoBehaviour {

	public static StayAwake instance;

	void Awake(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

}
