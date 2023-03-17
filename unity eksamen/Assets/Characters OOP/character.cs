using UnityEngine;
public abstract class character : MonoBehaviour, characterInterface
{
	public int vitality;
	public int strength;
	public int agility;
	public int abilityHaste;
	public enum action
	{
		Move,
		Attack,
		Defend
	}
	public abstract void decide();
	public abstract void doSomething();
	
	}