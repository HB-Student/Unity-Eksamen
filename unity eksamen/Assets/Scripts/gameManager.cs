using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gameManager : MonoBehaviour
{
	public levelSystem levelSys;
    public levelsUI levelUI;
	public orbOfLight theOrb;
    public orbOfLight orbOfLight;
	public GameObject Wizard;
	public GameObject Warrior;
	public GameObject Slime;
	public GameObject Goblin;
	public Dictionary<string, int> prices=new Dictionary<string, int>();
	public List<level> levels = new List<level>();
	public gameState currentGamestate;
	public gameLevelUI UiElement;
	public level nextLevel;
	public level currentLevel;
	public int money;
	public buyMenu buyMenu;
	public void spawnHero(string heroType)
	{
		GameObject entity;
		switch (heroType)
		{
			case "wizard":
				entity = Wizard;
				break;
			case "warrior":
				entity = Warrior;
				break;
			default:
				return;
		}
		GameObject hero = Instantiate(entity, randomAroundOrb(3), Quaternion.identity);
		hero.transform.SetParent(GameObject.Find(heroType).transform);
	}

	public void buyHero(string heroToBuy){
		GameObject entity;
		switch (heroToBuy)
		{
			case "wizard":
				entity = Wizard;
				break;
			case "warrior":
				entity = Warrior;
				break;
			default:
				return;
		}
		if(entity.GetComponent<hero>().price<=money){
			spawnHero(heroToBuy);
			money-=entity.GetComponent<hero>().price;
			buyMenu.setMoney(money);
		}
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

	public void addMoney(int amount){
		money+=amount;
		buyMenu.setMoney(money);
	}
	void Start(){
		for (int i = 0; i < 6; i++)
		{
			spawnHero("warrior");
		}
	
		buyMenu.setButtons(new List<hero>{Wizard.GetComponent<hero>(),Warrior.GetComponent<hero>()});
		levels.Add(new level(1,10000,10,1));
		levels.Add(new level(2,120,0,6));
		levels.Add(new level(3,130,2,1));
		levels.Add(new level(4,120,2,2));
		levels.Add(new level(5,130,4,1));
		levels.Add(new level(6,120,2,5));
		levels.Add(new level(7,130,5,4));
		nextLevel=levels[0];

		money=0;
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