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
		if (scanBool("monster", sightRadius.totalStat(), target.transform))
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
		Destroy(gameObject);
	}
}