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
	public gameState currentGamestate;
	public gameLevelUI UiElement;
	public level nextLevel;
	public level currentLevel;
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
		monster.GetComponent<monster>().setLevel(currentLevel);
		monster.transform.SetParent(GameObject.Find(monsterType).transform);
	}
	}

	void Start(){
		spawnHero("wizard");
		spawnHero("wizard");
		spawnHero("wizard");
		spawnHero("wizard");

		levels.Add(new level(1,1000,1,1));
		levels.Add(new level(2,120,1,2));
		levels.Add(new level(3,130,2,1));
		nextLevel=levels[0];
	}

	public void startNextLevel(){
		if (nextLevel!=null){
		currentLevel=nextLevel;
		currentLevel.startLevel();
		if(levels.Count-1>=levels.IndexOf(nextLevel)+1){
		nextLevel=levels[levels.IndexOf(nextLevel)+1];
		}else{
			nextLevel=null;
		}
		}
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
	public enum gameState{
		inPlay,
		betweenPlay
	}
}