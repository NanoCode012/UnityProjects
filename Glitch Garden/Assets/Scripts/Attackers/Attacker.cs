using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (Health))]
public abstract class Attacker : MonoBehaviour
{
    protected float currentSpeed;
    protected GameObject currentTarget;
    protected Animator animator;
    protected Rigidbody2D myRigidbody2D;

    // Use this for initialization
    void Start()
    {
        myRigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody2D.isKinematic = true;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody2D.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void StrikeCurrentTarget(float damage)
    {
        if (currentTarget != null)
        {     
			var currentTargetHPComponent = currentTarget.GetComponent<Health>();
            if (currentTargetHPComponent != null)
            {
				currentTargetHPComponent.DealDamage(damage);
            }
        }
        else
        {
            AttackStop();
        }
    }

    protected void Jump()
    {
        animator.SetTrigger("jumpTrigger");
    }

    protected void AttackStart(GameObject obj)
    {
        currentTarget = obj;
        animator.SetBool("isAttacking", true);
    }

    private void AttackStop()
    {
        animator.SetBool("isAttacking", false);
    }

    public abstract void OnTriggerEnter2D(Collider2D collision);
}
