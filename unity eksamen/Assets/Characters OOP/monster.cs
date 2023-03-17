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

public class lootTable{
	public List<GameObject> slimeDrops = new List<GameObject>();
	public List<int> slimeChances = new List<int>();
	public List<drop> getTable (string type){
		List<drop> loot = new List<drop>();
		switch (type)
		{
			case "slime":
				for (int i = 0; i < slimeChances.Count; i++)
				{
					loot.Add(new drop(slimeChances[i],slimeDrops[i]));
				}
				return loot;
			default:
			return loot;
		}
	}
}

public abstract class monster : character
{	public void dead(string monstertype){
		lootTable lootList = new lootTable();
		List<drop> drops = lootList.getTable(monstertype);
		foreach (var drop in drops)
		{
			if (Random.Range(0,100)<=drop.dropChance){
				Instantiate(drop.item,transform.position,Quaternion.identity);
			}
		}
		Destroy(gameObject);
	}
}