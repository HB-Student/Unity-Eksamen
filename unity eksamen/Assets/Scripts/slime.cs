using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : monster
{
	void Start()
	{
		monsterStart();
		monsterType = "slime";
		health = 10;
		sightRadius.baseStat = 4;
	}
	void Update()
	{
		monsterUpdate();
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
				target.transform.position = enemy.transform.position;
				if (!cooldownOn)
				{
					cooldownOn = true;
					StartCoroutine(dash());
				}
				else
				{
					move();
				}
				break;

			default:
				return;
		}
	}
	public bool touchingHero = false;
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "hero")
		{
			touchingHero = true;
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "hero")
		{
			touchingHero = false;
		}
	}

	IEnumerator dash()
	{
		float startTime = Time.time;
		agility.bonusPercentage += 100;
		yield return new WaitUntil(new Func<bool>(() => touchingHero || Time.time - startTime >= 3));
		if (Time.time - startTime <= 3)
		{
			startTime = Time.time;
			agility.bonusPercentage = -100;
			List<GameObject> enemies = scanList("hero", 0.75f);
			foreach (var enemy in enemies)
			{
				enemy.GetComponent<hero>().takeDamage(5);
			}
			yield return new WaitUntil(new Func<bool>(() => Time.time - startTime >= 3 / (1 + 0.1f * abilityHaste.totalStat())));
		}
		agility.bonusPercentage = GetComponentInParent<characterManager>().agility.bonusPercentage;
		cooldownOn = false;
	}
}