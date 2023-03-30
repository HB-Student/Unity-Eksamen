using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class character : scanners, characterInterface
{
    public enum action
    {
        Idle,
        Move,
        combat
    }

    public Dictionary<string,int> Stats = new Dictionary<string, int>();
    public action doing = action.Idle;
    public Color originalColor;
    public int health;
    public stat vitality = new stat("vitality");
    public stat strength = new stat("strength");
    public stat agility = new stat("agility");
    public stat abilityHaste = new stat("abilityHaste");
    public bool cooldownOn = false;
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

    public GameObject target;
    public void characterStart()
    {
        Color originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        target = new GameObject("target");
        target.transform.position = (Vector2)transform.position;
    }

    public void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, agility.totalStat() * 0.01f);
    }
}