using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class scavenger : hero
{
	float startTime;
	bool holdingLoot = false;
	void Start()
	{
		health = 10;
		characterStart();
		sightRadius.baseStat = 3;
	}
	void Update()
	{
		decide();
		doSomething();
	}
	public override void doSomething()
	{
		if (holdingLoot)
		{
			float dist = Vector2.Distance(transform.position, new Vector2(0, 0));
			if (dist <= 2.5f)
			{
				gm.addMoney(1);
                holdingLoot = false;
			}
			else
			{
				target.transform.position = new Vector2(0, 0);
				move();
			}
			return;
		}
		switch (doing)
		{
			case action.Move:
				move();
				break;
			case action.collect:
				float space = (float)1.14f * 0.5f * (transform.localScale.x + enemy.transform.localScale.x);
				if (Vector2.Distance(transform.position, enemy.transform.position) <= space)
				{
					Destroy(enemy);
					holdingLoot = true;
				}
				else
				{
					moveToEnemy();
				}
				break;
			default:
				return;
		}
	}
}