using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class wizard : hero
{
	float startTime;
	public GameObject projectile;
	void Start()
	{
		health = 10;
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
                if (Vector2.Distance(transform.position, target.transform.position) >= 0.75)
                {
                    move();
                }
                else if (!cooldownOn)
				{
					cooldownOn = true;
					StartCoroutine(magicBall());
				}
				break;

			default:
				return;
		}
	}
	IEnumerator magicBall()
	{
		GameObject magicBall = Instantiate(projectile, transform.position, Quaternion.identity);
		magicBall.GetComponent<wizardBullet>().target = enemy;
		magicBall.GetComponent<wizardBullet>().damage = strength.totalStat();
		yield return new WaitForSeconds(3 / (1 + 0.1f * abilityHaste.totalStat()));

		cooldownOn = false;
	}
}