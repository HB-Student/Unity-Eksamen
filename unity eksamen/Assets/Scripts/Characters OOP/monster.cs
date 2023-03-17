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
	public lootTable lootList;
	void Start(){
		lootList = GameObject.FindGameObjectWithTag("lootTable").GetComponent<lootTable>();
	}

	public void dead(string monstertype){
		List<drop> drops = lootList.getTable(monstertype);
		print(drops[1].item);
		foreach (var drop in drops)
		{
			if (Random.Range(0,100)<=drop.dropChance){
				Instantiate(drop.item,gameObject.transform.position,Quaternion.identity);
			}
		}
		Destroy(gameObject);
	}
}