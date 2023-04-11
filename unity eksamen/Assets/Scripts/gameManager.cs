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
		GameObject monster = Instantiate(entity, randomAroundOrb(), Quaternion.identity);
		monster.transform.SetParent(GameObject.Find(monsterType).transform);
	}

	public int radius = 80;
	void Start(){
		spawnMonster("slime");
		spawnMonster("slime");
		spawnMonster("slime");
		spawnMonster("slime");
		spawnMonster("slime");
		spawnMonster("slime");
	}
	void Update()
	{
		
	}
	Vector2 randomAroundOrb()
	{
		int angle = Random.Range(0,360);
		float x = Mathf.Cos(angle) * radius;
		float y = Mathf.Sin(angle) * radius;
		return new Vector2 (x,y);
	}
}