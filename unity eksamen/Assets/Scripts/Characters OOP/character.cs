using UnityEngine;
public abstract class character : MonoBehaviour, characterInterface
{
	public int health;
	public int vitality;
	public int strength;
	public int agility;
	public int abilityHaste;
	public enum action
	{
		Idle,
		Move,
		combat
	}
	public action doing = action.Idle;
	public abstract void decide();
	public abstract void doSomething();
	public void takeDamage(int damage){
		health-=damage;
	}
	public int scanRadius;
	GameObject enemy;
	public bool scan(string opponentTag)
	{
		Collider[] overlapCollider = Physics.OverlapSphere(transform.position, scanRadius);
		for (int i = 0; i < overlapCollider.Length; i++)
		{
			if (overlapCollider[i].gameObject.tag == opponentTag){
				enemy = overlapCollider[i].gameObject;
				return true;
			}
		}
		return false;
	}
	}