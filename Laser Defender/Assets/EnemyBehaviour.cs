using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D col)
	{
        if (col.GetComponent<Projectile>())//it seems this takes slightly more time
        //if (col.gameObject.name == "AcidBallClone)")//this is slightly faster but 
                                                      //What if there is more types of projectile? 
                                                      //This line won't cover it like the one above
        {
            print("Got hit");
        }
	}
}
