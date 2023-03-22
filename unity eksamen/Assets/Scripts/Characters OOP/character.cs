using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class character : MonoBehaviour, characterInterface
{
    public enum action
    {
        Idle,
        Move,
        combat
    }
    public action doing = action.Idle;
    public int health;
    public int vitality;
    public int strength;
    public int agility;
    public int abilityHaste;
    public abstract void decide();
    public abstract void doSomething();

    public void takeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(damageVisual());
    }

    IEnumerator damageVisual()
    {
        Color originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }

    public int sightRadius;
    public GameObject enemy;

    public bool enemyScan(string opponentTag, int colliderRadius)
    {
        Collider[] overlapCollider = Physics.OverlapSphere(transform.position, colliderRadius);
        for (int i = 0; i < overlapCollider.Length; i++)
        {
            if (overlapCollider[i].gameObject.tag == opponentTag)
            {
                enemy = overlapCollider[i].gameObject;
                return true;
            }
        }
        return false;
    }

    public GameObject target;

    public void createTarget()
    {
        target = new GameObject("target");
        target.transform.position = (Vector2)transform.position;
    }

    public void move()
    {
        if (Vector2.Distance(transform.position, target.transform.position) <= 1)
        {
            doing = action.Idle;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, agility * 0.01f);
        }
    }
}