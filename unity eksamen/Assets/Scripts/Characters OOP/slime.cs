using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : monster
{
	public bool moveing = false;
	string monsterType = "slime";

	public void Start(){
		health = 100;
		agility = 1;
		scanRadius = 4;
		
	}
	bool cooldownOn = false;

	public override void doSomething()
	{
		switch (doing)
		{
			case action.Move:
			move();
			break;
			
			case action.combat:
			if (!cooldownOn){
				cooldownOn = true;
				StartCoroutine(combat());
			}
			break;

			default:
			return;
		}
	}
	IEnumerator combat(){
		chooseMove();
		yield return new WaitForSeconds(3/abilityHaste);
		cooldownOn = false;
	}
	public void chooseMove(){
		int randomInt = Random.Range(1,3);
		switch (randomInt)
		{
			case 1:
			break;
			
			case 2:
			break;

			case 3:
			break;

			default:
			return;
		}
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.E)){
			dead();
		}
		if (Input.GetKey(KeyCode.S)){
			decide();
			doSomething();
		}
	}
}