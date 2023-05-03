using System.Collections.Generic;
using UnityEngine;

public abstract class monster : character
{
	lootTable lootList;
	public string monsterType;
	private level level;
	public int hitPoint;
	public int dropMoney;
	 
	public void monsterStart()
	{
		characterStart();
		lootList = GameObject.FindGameObjectWithTag("lootTable").GetComponent<lootTable>();
	}
	public void monsterUpdate()
	{

	}

	public void setLevel(level levelToSet){
		level=levelToSet;
	}
	public override void dead()
	{
		level.killMonster();
		if(killed==true){
            List<GameObject> drops = lootList.getTable(monsterType);
            foreach (var drop in drops)
            {
                if (Random.Range(0, 100) <= drop.GetComponent<drop>().dropChance)
                {
                    int angle = Random.Range(0, 360);
                    float x = Mathf.Cos(angle);
                    float y = Mathf.Sin(angle);

                    Instantiate(drop, gameObject.transform.position + new Vector3(x, y, 0), Quaternion.identity);
                }
            }
		}
		Destroy(gameObject);
	}
	public override void decide()
	{
		if (Vector2.Distance(transform.position, target.transform.position) <= 1f)
		{
			target.transform.position = transform.position;
		}
		if (scanBool("hero", sightRadius.totalStat(),transform))
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
	    	killed=false;
			this.dead();
		}
	}
}