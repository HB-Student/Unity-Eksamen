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
    public Color originalColor;
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
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public int sightRadius;
    public GameObject enemy;

    public bool scanBool(string opponentTag, int colliderRadius)
    {
        Collider2D[] overlapCollider = Physics2D.OverlapCircleAll(transform.position, colliderRadius);
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

    public List<GameObject> scanList(string scanningTag, int colliderRadius)
    {
        Collider2D[] overlapCollider = Physics2D.OverlapCircleAll(transform.position, colliderRadius);
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

    public GameObject target;

    public void fakeStart()
    {
        Color originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        target = new GameObject("target");
        target.transform.position = (Vector2)transform.position;
    }

    public void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, agility * 0.01f);
    }
}