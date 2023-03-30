using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : monster
{
    void Start()
    {
        monsterStart();
        monsterType = "slime";
        health = 100;
        sightRadius.baseStat = 4;
    }
    void Update()
    {
        monsterUpdate();
        decide();
        doSomething();
    }
    public override void doSomething()
    {
        switch (doing)
        {
            case action.Move:
                move();
                break;
            case action.combat:
                target.transform.position = enemy.transform.position;
                if (!cooldownOn)
                {
                    cooldownOn = true;
                    StartCoroutine(dash());
                }
                break;

            default:
                return;
        }
    }
    IEnumerator dash()
    {
        float startTime = Time.time;
        agility.bonusPercentage+=60;
        yield return new WaitUntil(new Func<bool>(() => scanBool("hero",1)));
        agility.bonusPercentage = -100;
        List<GameObject> enemies = scanList("hero", 1.2f);
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<hero>().takeDamage(5);
        }
        yield return new WaitUntil(new Func<bool>(() => Time.time-startTime >= 3/abilityHaste.totalStat()));
        agility.bonusPercentage = GetComponentInParent<characterManager>().agility.bonusPercentage;
        cooldownOn = false;
    }
/*
    public void chooseAttack()
    {
        switch (UnityEngine.Random.Range(1, 1))
        {
            case 1:
                break;
            default:
                return;
        }
    }
*/
}