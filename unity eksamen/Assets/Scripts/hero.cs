using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public abstract class hero : character
{
    public int price;
    public GameObject rangeVFX;
    public Sprite img;
    public string text;
	private Animation levelUpAnim;
	public override void decide()
	{
		if (gameObject.transform.parent.name == "scavenger")
		{
			if (scanBool("resource", sightRadius.totalStat(), gameObject.transform))
			{
				doing = action.collect;
			}
			else{
                doing = action.Move;
			}
		}
		else if (scanBool("monster", sightRadius.totalStat(), target.transform))
		{
			doing = action.combat;

		}
		else
		{
			doing = action.Move;
		}
	}
	public override void dead()
	{
		List<GameObject> rangeVFXList = GameObject.FindGameObjectWithTag("marker").GetComponent<marker>().controllingList;
		if (rangeVFXList.Contains(gameObject)){
            rangeVFXList.Remove(gameObject);
		}
        Destroy(gameObject.GetComponent<character>().target);
		Destroy(gameObject);
	}
    public void deleteRangeVFX(GameObject hero)
    {
		GameObject rangeParent;
		if (hero.transform.parent.name == "warrior")
		{
			rangeParent = hero.GetComponent<character>().target;
		}
		else
		{
			rangeParent = hero;
		}
		for (int i = 0; i < rangeParent.transform.childCount; i++)
		{
			if (rangeParent.transform.GetChild(i).tag == "range")
			{
				Destroy(rangeParent.transform.GetChild(i).gameObject);
			}
		}
	}
}