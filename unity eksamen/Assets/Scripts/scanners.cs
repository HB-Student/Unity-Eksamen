using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class scanners : MonoBehaviour
{
	public stat sightRadius = new stat("sightRadius");
	public GameObject enemy;

	public bool scanBool(string opponentTag, float colliderRadius)
	{
		List<GameObject> enemies = scanList(opponentTag, colliderRadius);
		if (enemies.Count > 0)
		{
			GameObject closestEnemy = enemies[0];
			float closestDist = Vector2.Distance(transform.position, closestEnemy.transform.position);
			foreach (var opponent in enemies)
			{
				float opponentDist = Vector2.Distance(transform.position, opponent.transform.position);
				if (opponentDist < closestDist)
				{
					closestEnemy = opponent;
					closestDist = opponentDist;
				}
			}
			enemy = closestEnemy;
			return true;
		}
		else
		{
			return false;
		}
	}

	public List<GameObject> scanList(string scanningTag, float colliderRadius)
	{
		Collider2D[] overlapCollider = Physics2D.OverlapCircleAll(transform.position, colliderRadius);
		List<GameObject> enemies = new List<GameObject>();
		for (int i = 0; i < overlapCollider.Length; i++)
		{
			if (overlapCollider[i].gameObject.tag == scanningTag)
			{
				enemies.Add(overlapCollider[i].gameObject);
			}
		}
		return enemies;
	}
}