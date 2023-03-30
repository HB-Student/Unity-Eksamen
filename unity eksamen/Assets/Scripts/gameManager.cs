using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gameManager : MonoBehaviour
{
	public GameObject Wizard;
	public GameObject Slime;
	public void spawnHero(string heroType)
	{
		GameObject entity;
		switch (heroType)
		{
			case "wizard":
				entity = Wizard;
				break;
			default:
				return;
		}
		GameObject hero = Instantiate(entity, new Vector2(0, 0), Quaternion.identity);
		hero.transform.SetParent(GameObject.Find(heroType).transform);
	}
	public void spawnMonster(string monsterType)
	{
		GameObject entity;
		switch (monsterType)
		{
			case "slime":
				entity = Slime;
				break;
			default:
				return;
		}
		Vector2 whereShouldItBePlaced = new Vector2(0,0);
		GameObject monster = Instantiate(entity, whereShouldItBePlaced, Quaternion.identity);
		monster.transform.SetParent(GameObject.Find(monsterType).transform);
	}
}