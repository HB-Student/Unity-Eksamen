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
	public GameObject Scavenger;
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
            case "scavenger":
                entity = Scavenger;
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
            case "scavenger":
                entity = Scavenger;
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
		for (int i = 0; i < 2; i++)
		{
			spawnHero("scavenger");
            spawnHero("warrior");
            spawnHero("wizard");
		}
	
		buyMenu.setButtons(new List<hero>{
			Wizard.GetComponent<hero>(),
			Warrior.GetComponent<hero>(),
			Scavenger.GetComponent<hero>()});
		levels.Add(new level(1,70, 1, 3));
		levels.Add(new level(2,80,3,2));
		levels.Add(new level(3,100,7,4));
		levels.Add(new level(4,120,10,0));
		levels.Add(new level(5,180,10,3));
		levels.Add(new level(6,240,10,5));
		levels.Add(new level(7,290,13,7));
		levels.Add(new level(8,100,19,3));
		levels.Add(new level(9,350,15,10));
		levels.Add(new level(10,102,10,15));
		levels.Add(new level(11,202,7,8));
		levels.Add(new level(12,203,4,4));
		levels.Add(new level(13,380,5,4));
		levels.Add(new level(14,420,10,0));
		levels.Add(new level(15,420,0,10));
		levels.Add(new level(16,420,7,8));
		levels.Add(new level(17,420,4,4));
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