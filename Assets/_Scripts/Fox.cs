using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour
{
	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject gameObject = collision.gameObject;

		// Leave method if not colliding with defender
		if (!gameObject.GetComponent<Defender>())
		{
			return;
		}

		if (gameObject.GetComponent<Stone>())
		{
			anim.SetTrigger("jump trigger");
		}
		else
		{
			anim.SetBool("isAttacking", true);
			attacker.Attack(gameObject);			
		}
	}
}
