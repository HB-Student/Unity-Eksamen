using System.Collections.Generic;
using UnityEngine;

public abstract class monster : character
{
	lootTable lootList;
	public string monsterType;
	private level level;
	public int hitPoint;
	public void monsterStart()
	{
		characterStart();
		//lootList = GameObject.FindGameObjectWithTag("lootTable").GetComponent<lootTable>();
	}
	public void monsterUpdate()
	{
		if (health <= 0 || scanBool("orb", 1))
		{
			dead();
		}
	}

	public void setLevel(level levelToSet){
		level=levelToSet;
	}
	public void dead()
	{
		//List<drop> drops = lootList.getTable(monsterType);
		//foreach (var drop in drops)
		//{
		//	if (Random.Range(0, 100) <= drop.dropChance)
		//	{
		//		Instantiate(drop.item, gameObject.transform.position, Quaternion.identity);
		//	}
		//}
		level.killMonster();
		Destroy(gameObject);
	}
	public override void decide()
	{
		if (Vector2.Distance(transform.position, target.transform.position) <= 1f)
		{
			target.transform.position = transform.position;
		}
		if (scanBool("hero", sightRadius.totalStat()))
		{
			doing = action.combat;
		}
		else
		{
			target.transform.position = new Vector2(0, 0);
			doing = action.Move;
		}
	}

    void OnTriggerEnter2D (Collider2D collision)
	{
	    // Check if the colliding object has a specific tag
	    if (collision.gameObject.name=="damageZone")
	    {
	        // Do something when the moving object collides with the stationary object
			collision.gameObject.transform.parent.GetComponent<orbOfLight>().TakeDamage(hitPoint);
	    	this.dead();
		}
	}
}