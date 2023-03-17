using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : monster
{
	public override void decide()
	{
		throw new System.NotImplementedException();
	}

	public override void doSomething()
	{
		throw new System.NotImplementedException();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.E)){
			dead("slime");
		}
	}
}