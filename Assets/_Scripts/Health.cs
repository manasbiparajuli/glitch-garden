using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] float health;

	public void DealDamage(float damage)
	{
		health -= damage;

		if (health <= 0)
		{
			// Optionally trigger animation
			DestroyObject();
		}
	}

	public void DestroyObject()
	{
		Destroy(gameObject);
	}
}
