using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour
{
	[Tooltip("Average number of seconds between appearances")]
	[SerializeField] private float seenEverySeconds;

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
		rigidbody2D.isKinematic = true;

		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);		

		if (!currentTarget)
		{
			animator.SetBool("isAttacking", false);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

	}

	public void SetSpeed (float speed)
	{
		currentSpeed = speed;
	}

	// Called from the animator at time of actual blow
	public void StrikeCurrentTarget (float damage)
	{
		if (currentTarget)
		{
			Health health = currentTarget.GetComponent<Health>();
				
			if (health)
			{
				health.DealDamage(damage);
			}
		}
	}
	
	public void Attack (GameObject gameObject)
	{
		currentTarget = gameObject;
	}

	public float GetSeenEverySeconds()
	{
		return seenEverySeconds;
	}
}
