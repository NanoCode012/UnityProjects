using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    Slider health;
	void Start () {
        health = GetComponent<Slider>();
        var hp = FindObjectOfType<PlayerController>().health;

        health.maxValue = hp;
        health.value = hp;
	}

    public void Hit(float damage)
    {
        health.value -= damage;
    }
}
