using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : monster
{
	void Start()
	{
		monsterStart();
		monsterType = "goblin";
		health = 20;
		sightRadius.baseStat = 4;
		agility.baseStat = 1;
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