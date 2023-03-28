using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : monster
{

    void Start()
    {
        monsterStart();
        monsterUpdate();
        monsterType = "slime";
        health = 100;
        agility.baseStat = 1;
        sightRadius.baseStat = 4;
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
                    chooseAttack();
                }
                break;

            default:
                return;
        }
    }

    public void chooseAttack()
    {
        int randomInt = UnityEngine.Random.Range(1, 1);
        switch (randomInt)
        {
            case 1:
                StartCoroutine(dash());
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                return;
        }
    }

    IEnumerator dash()
    {
        float startTime = Time.time;
        int startSpeed = agility.bonusPercentage;
        agility.bonusPercentage+=40;
        yield return new WaitUntil(new Func<bool>(() => scanBool("hero",1)));
        agility.bonusPercentage = -100;
        List<GameObject> enemies = scanList("hero", 1.5f);
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<hero>().takeDamage(5);
        }
        yield return new WaitUntil(new Func<bool>(() => Time.time-startTime >= 2));
        cooldownOn = false;
        agility.bonusPercentage = startSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dead();
        }
        decide();
        doSomething();
    }
}