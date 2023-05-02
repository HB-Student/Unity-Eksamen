using UnityEngine;

public abstract class hero : character
{
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