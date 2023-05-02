using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class warrior : hero
{
	float startTime;
	void Start()
	{
		health = 100;
		characterStart();
		sightRadius.baseStat = 6;
	}
	void Update()
	{
		decide();
		doSomething();
	}
	public override void doSomething()
	{
		switch (doing)
		{
			case action.Move:
				move();
				break;

			case action.combat:
				if (!cooldownOn)
				{
					cooldownOn = true;
					StartCoroutine(attack());
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
	IEnumerator attack()
	{
		if (scanList("monster", 1f).Count > 0)
		{
			enemy.GetComponent<monster>().takeDamage(strength.totalStat());
			yield return new WaitForSeconds(2 / (1 + 0.1f * abilityHaste.totalStat()));
		}
		else
		{
			moveToEnemy();
		}
		cooldownOn = false;
	}
}