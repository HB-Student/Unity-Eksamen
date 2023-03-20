using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop{
	public int dropChance;
	public GameObject item;
	public drop(int c, GameObject d){
		dropChance = c;
		item = d;
	}
}

public abstract class monster : character
{	
	lootTable lootList;
	void Start(){
		lootList = GameObject.FindGameObjectWithTag("lootTable").GetComponent<lootTable>();
	}

	public void dead(string monstertype){
		List<drop> drops = lootList.getTable(monstertype);
		foreach (var drop in drops)
		{
			if (Random.Range(0,100)<=drop.dropChance){
				Instantiate(drop.item,gameObject.transform.position,Quaternion.identity);
			}
		}
		Destroy(gameObject);
	}
}