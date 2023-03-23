using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : monster
{

    void Start()
    {
        createTarget();
        monsterType = "slime";
        health = 100;
        agility = 1;
        sightRadius = 4;
    }

    bool cooldownOn = false;

    public override void doSomething()
    {
        switch (doing)
        {
            case action.Move:
                target.transform.position = new Vector2(0, 0);
                move();
                break;
            case action.combat:
                target.transform.position = enemy.transform.position;
                if (!cooldownOn)
                {
                    cooldownOn = true;
                    chooseAttack();
                }
                move();
                break;

            default:
                return;
        }
    }

    public void chooseAttack()
    {
        int randomInt = Random.Range(1, 1);
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
        agility++;
        yield return new WaitForSeconds(1f);
        agility--;
        List<GameObject> enemies = scanList("hero", 2);
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<hero>().takeDamage(5);
        }
        cooldownOn = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dead();
        }
        if (Input.GetKey(KeyCode.S))
        {

        }
        decide();
        doSomething();
    }
}