using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class character : scanners, characterInterface
{
	public enum action
	{
		collect,
		Move,
		combat
	}

	public Dictionary<string, int> Stats = new Dictionary<string, int>();
	public action doing;
	public Color originalColor;
	public int health;
	public stat vitality = new stat("vitality");
	public stat strength = new stat("strength");
	public stat agility = new stat("agility");
	public stat abilityHaste = new stat("abilityHaste");

	public gameManager gm;
	public bool cooldownOn = false;
	protected bool killed;
	public abstract void decide();
	public abstract void doSomething();
	public abstract void dead();
	public HealtbarScript healtbar = null;
	public void takeDamage(int damage)
	{
		health -= damage;
		if(health<=0){
			killed=true;
			this.dead();
		}
		if (healtbar != null)
		{
			healtbar.updateHealthBar(health);
		}
		StartCoroutine(damageVisual());
	}


	IEnumerator damageVisual()
	{
		gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		yield return new WaitForSeconds(0.2f);
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
	}

	public GameObject target;
	public void characterStart()
	{
		gm = GameObject.Find("GameManager").GetComponent<gameManager>();
		if (healtbar != null)
		{
			healtbar.setMax(health);
		}
		Color originalColor = gameObject.GetComponent<SpriteRenderer>().color;
		target = new GameObject("target");
		target.transform.position = new Vector2(0, 0);
	}

	public void move()
	{
		if (Vector2.Distance(transform.position, target.transform.position) <= 0.75f * gameObject.transform.localScale.x)
		{
			target.transform.position = transform.position;
		}
		else
		{
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 0.02f + agility.totalStat() * 0.002f);
		}
	}
	public void moveToEnemy()
	{
		float space = (float)1.14f * 0.5f * (transform.localScale.x + enemy.transform.localScale.x);
		if (Vector2.Distance(transform.position, enemy.transform.position) > space)
		{
			transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, 0.02f + agility.totalStat() * 0.002f);
		}
	}
}