using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private float hp = 100;

    public void DealDamage(float damage)
    {
        hp -= damage;
        if (IsDead()) 
        {
            //Can initiate death animation here, remove line below, call from
            //animation events of the death animation instead
            DestroyGameObject();
        }
    }

    private bool IsDead()
    {
        return (hp <= 0);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
