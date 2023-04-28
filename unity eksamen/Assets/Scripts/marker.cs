using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marker : MonoBehaviour
{
	Vector2 mousePosStart;
	Vector2 mousePosNow;
	Vector2 mouseDiff;
	public List<GameObject> controllingList;
	public GameObject rangeVFX;

	void Start()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}

	void Update()
	{
		markerUpdate();
		checkForMove();
		offsetVisual();
	}

	public void markerUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			mousePosStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		if (Input.GetMouseButton(0))
		{
			mousePosNow = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.localScale = mousePosNow - mousePosStart;
		}
		if (Input.GetMouseButtonUp(0))
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			controlHeros();
		}
	}
	public List<GameObject> controlHeros()
	{
		if (controllingList.Count != 0)
		{
			foreach (var hero in controllingList)
			{
				for (int i = 0; i < hero.transform.childCount; i++)
				{
					if (hero.transform.GetChild(i).tag == "range")
					{
						Destroy(hero.transform.GetChild(i).gameObject);
					}
				}
			}
		}
		controllingList = scanList("hero", gameObject);
		foreach (var hero in controllingList)
		{
			GameObject rangeClone = Instantiate(rangeVFX, hero.transform);
			int scale = 2 * hero.GetComponent<hero>().sightRadius.totalStat();
			rangeClone.transform.localScale = new Vector2(scale, scale);
		}
		return controllingList;
	}

	public void checkForMove()
	{
		if (Input.GetMouseButtonDown(1))
		{
			foreach (var hero in controllingList)
			{
				hero.GetComponent<hero>().target.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}
		}
	}

	public void offsetVisual()
	{
		if (mouseDiff.x > 0)
		{
			transform.position = new Vector2((float)(mousePosStart.x - 0.5 * transform.localScale.x), transform.position.y);
		}
		else
		{
			transform.position = new Vector2((float)(mousePosStart.x + 0.5 * transform.localScale.x), transform.position.y);
		}
		if (mouseDiff.y > 0)
		{
			transform.position = new Vector2(transform.position.x, (float)(mousePosStart.y - 0.5 * transform.localScale.y));
		}
		else
		{
			transform.position = new Vector2(transform.position.x, (float)(mousePosStart.y + 0.5 * transform.localScale.y));
		}
	}

	public List<GameObject> scanList(string scanningTag, GameObject marker)
	{
		Collider2D[] overlapCollider = Physics2D.OverlapAreaAll(mousePosStart, mousePosNow);
		List<GameObject> enemies = new List<GameObject>();
		for (int i = 0; i < overlapCollider.Length; i++)
		{
			if (overlapCollider[i].gameObject.tag == scanningTag)
			{
				enemies.Add(overlapCollider[i].gameObject);
			}
		}
		return enemies;
	}
}
