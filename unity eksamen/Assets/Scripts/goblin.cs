using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : monster
{
	void Start()
	{
		monsterStart();
		hitPoint=20;
		monsterType = "goblin";
		sightRadius.baseStat = 4;
		agility.baseStat = 3;
	}
	void Update()
	{
		monsterUpdate();
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
				move();
				break;
			default:
				return;
		}
	}

}