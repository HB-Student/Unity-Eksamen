using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class radarScanner : scanners
{
	public List<GameObject> radarMonsters;
	void Update(){
		radarMonsters = scanList("monster",100,transform);
	}

}