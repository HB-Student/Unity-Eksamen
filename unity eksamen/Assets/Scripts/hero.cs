using UnityEngine;
using UnityEngine.UI;
public abstract class hero : character
{
    public int price;
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
		if (transform.parent.name == "warrior"){
			GameObject rangeVFX = gameObject.GetComponent<warrior>().rangeVFX;
			if (rangeVFX != null)
			{
				GameObject.Find("Marker(Clone)").GetComponent<marker>().controllingList.Remove(rangeVFX);
				Destroy(rangeVFX);
			}
		}
		Destroy(gameObject);
	}
}