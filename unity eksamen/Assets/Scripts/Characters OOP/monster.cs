using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop
{
    public int dropChance;
    public GameObject item;
    public drop(int c, GameObject d)
    {
        dropChance = c;
        item = d;
    }
}

public abstract class monster : character
{
    lootTable lootList;
    public string monsterType;
    void Start()
    {
        lootList = GameObject.FindGameObjectWithTag("lootTable").GetComponent<lootTable>();
    }
    void Update()
    {
        if (health <= 0)
        {
            dead();
        }
    }

    public void dead()
    {
        List<drop> drops = lootList.getTable(monsterType);
        foreach (var drop in drops)
        {
            if (Random.Range(0, 100) <= drop.dropChance)
            {
                Instantiate(drop.item, gameObject.transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }
    public override void decide()
    {
        if (Vector2.Distance(transform.position, target.transform.position) <= 1f){
            target.transform.position = transform.position;
            if (scanBool("hero", sightRadius))
            {
                doing = action.combat;
            }
            else
            {
                doing = action.Move;
            }
        }
        else
        {
            doing = action.Move;
        }
    }
}