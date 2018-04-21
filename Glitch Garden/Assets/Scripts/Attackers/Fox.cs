using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Attacker {
    
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.CompareTag("Projectile"))
        {
            //lose hp
        }
        else if (obj.CompareTag("Block"))
        {
            //Jump
            print(name + " jumped over " + collision.name);
            Jump();
        }
        else
        {
            AttackStart(obj);
        }
    }
}
