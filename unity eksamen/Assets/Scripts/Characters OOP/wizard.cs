using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class wizard : hero
{
	bool cooldownOn = false;
	float startTime;
	void Start(){
		scanRadius = 7;
	}
	
	public override void decide()
	{
		if (scan("monster")){
			doing = action.combat;
		}
		else {
			if (doing != action.Move){
			doing = action.Idle;
			}
		}
	}

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
				startTime = Time.time;
			} else {
				if(startTime+3/abilityHaste-Time.time <= 0){
					// Add a shot projectile here.
					cooldownOn = false;
				}
			}
			break;

			default:
			return;
		}
	}
	void Update(){
		decide();
	}
}