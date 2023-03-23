using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class wizard : hero
{
    bool cooldownOn = false;
    float startTime;
    public GameObject projectile;
    void Start()
    {
        createTarget();
        health = 100;
        agility = 1;
        sightRadius = 6;
    }

    public override void doSomething()
    {
        switch (doing)
        {
            case action.Move:
                move();
                break;

            case action.combat:
                if (!cooldownOn)
                {
                    cooldownOn = true;
                    startTime = Time.time;
                }
                else
                {
                    if (startTime + 3 / abilityHaste - Time.time <= 0)
                    {
                        GameObject magicBall = Instantiate(projectile,transform.position,Quaternion.identity);
                        magicBall.GetComponent<chase>().target = enemy;
                        magicBall.GetComponent<chase>().damage = 10*strength;
                        cooldownOn = false;
                    }
                }
                break;

            default:
                return;
        }
    }
    void Update()
    {
        decide();
        doSomething();
    }
}