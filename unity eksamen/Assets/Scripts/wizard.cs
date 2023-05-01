using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class wizard : hero
{
	float startTime;
	public GameObject projectile;
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
		magicBall.GetComponent<wizardBullet>().damage = 10 * strength.totalStat();
		yield return new WaitForSeconds(3 / (1 + 0.1f * abilityHaste.totalStat()));
		Debug.Log("vitality " + vitality.totalStat());
		Debug.Log("strength " + strength.totalStat());
		Debug.Log("agility " + agility.totalStat());
		Debug.Log("abilityHaste " + abilityHaste.totalStat());

		cooldownOn = false;
	}
}