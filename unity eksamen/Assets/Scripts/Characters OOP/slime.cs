using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : monster
{
	public bool moveing = false;
	GameObject target;

	public void Start(){
		health = 100;
		agility = 1;
		scanRadius = 4;

		target = new GameObject("target");
		target.transform.position = new Vector2(0,0);
	}

	public override void decide()
	{
		if (scan("hero")){
			doing = action.combat;
		}
		 else {
			doing = action.Move;
		}
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

	public void move(){
		transform.position = Vector2.MoveTowards(transform.position,target.transform.position,agility*0.01f);
		doing = action.Idle;
	}

	public void checkIfDead(){
		if (health<=0)
		{
			dead("slime");
		}
	}

	void Update(){
		checkIfDead();
		if (Input.GetKeyDown(KeyCode.E)){
			dead("slime");
			print("Killed Slime");
		}
		if (Input.GetKey(KeyCode.S)){
			decide();
			doSomething();
		}
	}
}