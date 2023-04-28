using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gameManager : MonoBehaviour
{
	public levelSystem levelSys;
    public levelsUI levelUI;
    public orbOfLight orbOfLight;
	public GameObject Wizard;
	public GameObject Slime;
	public GameObject Goblin;
	public List<level> levels = new List<level>();
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
	public void spawnMonster(string monsterType,int amount)
	{
				GameObject entity;
		switch (monsterType)
		{
			case "slime":
				entity = Slime;
				break;
			case "goblin":
				entity = Goblin;
				break;
			default:
				return;
		}
		for (int i = 0; i < amount; i++)
		{
		GameObject monster = Instantiate(entity, randomAroundOrb(30), Quaternion.identity);
		monster.transform.SetParent(GameObject.Find(monsterType).transform);
	}
	}

	void Start(){
		spawnHero("wizard");
		levels.Add(new level(12,2));
		levels[0].startLevel();
		//for (int i = 0; i < 6; i++)
		//{
		//	spawnMonster("slime");
		//	spawnMonster("goblin");
		//}

	}
	Vector2 randomAroundOrb(int radius)
	{
		int angle = Random.Range(0,360);
		float x = Mathf.Cos(angle) * radius;
		float y = Mathf.Sin(angle) * radius;
		return new Vector2 (x,y);
	}
	    void Awake()
    {
        levelSys = new levelSystem();
        levelUI.setLevelSystem(levelSys);
        orbOfLight.setLevelSystem(levelSys);
    }

    public void addExp(int amount){
        levelSys.addExp(amount);
    }
}