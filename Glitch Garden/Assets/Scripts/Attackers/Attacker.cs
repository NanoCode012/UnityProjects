using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (Health))]
public abstract class Attacker : MonoBehaviour
{
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;
    private Rigidbody2D myRigidbody2D;

    // Use this for initialization
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.isKinematic = true;//Added as defense in case I forget to set to Kinematic

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

    protected bool CheckIfAttackerIsBehindDefender(GameObject obj)
    {
        return (transform.position.x <= obj.transform.position.x);
    }

    public abstract void OnTriggerEnter2D(Collider2D collision);
}
