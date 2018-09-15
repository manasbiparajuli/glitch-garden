using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] float speed, damage;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Attacker attacker = collision.gameObject.GetComponent<Attacker>();
		Health health = collision.gameObject.GetComponent<Health>();

		if (attacker && health)
		{
			health.DealDamage(damage);
			Destroy(gameObject);
		}
	}
}
