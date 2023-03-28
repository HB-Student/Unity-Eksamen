using System.Collections.Generic;
using UnityEngine;

public abstract class monster : character
{
    lootTable lootList;
    public string monsterType;
    public void monsterStart()
    {
        characterStart();
        lootList = GameObject.FindGameObjectWithTag("lootTable").GetComponent<lootTable>();
    }
    public void monsterUpdate(){
        if (health <= 0){
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
            if (scanBool("hero", sightRadius.totalStat()))
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