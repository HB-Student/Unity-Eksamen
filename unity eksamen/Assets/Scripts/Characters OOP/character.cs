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
	GameObject target;
	void Start(){
		target = new GameObject("target");
		target.transform.position = (Vector2)transform.position;
	}
	public void move(){
		transform.position = Vector2.MoveTowards(transform.position,target.transform.position,agility*0.01f);
		if (transform.position == target.transform.position){
			doing = action.Idle;
		}
	}
}