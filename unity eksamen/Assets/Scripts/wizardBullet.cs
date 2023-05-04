using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardBullet : scanners
{
	public GameObject target;
	public int speed;
	public int damage;

	void Update()
	{
		if (target != null)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 0.01f * speed);
			List<GameObject> enemies = scanList("monster", 1f,transform);
			if (enemies.Count > 0)
			{
				foreach (var enemy in enemies)
				{
					enemy.gameObject.GetComponent<monster>().takeDamage(damage);
				}
				Destroy(gameObject);
			}
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
