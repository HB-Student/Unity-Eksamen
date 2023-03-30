using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class wizard : hero
{
    float startTime;
    public GameObject projectile;
    void Start()
    {
        characterStart();
        health = 100;
        sightRadius.baseStat = 6;
    }
    void Update()
    {
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
                if (!cooldownOn)
                {
                    cooldownOn = true;
                    magicBall();
                }
                break;

            default:
                return;
        }
    }
    IEnumerator magicBall(){
        GameObject magicBall = Instantiate(projectile,transform.position,Quaternion.identity);
        magicBall.GetComponent<wizardBullet>().target = enemy;
        magicBall.GetComponent<wizardBullet>().damage = 10*strength.totalStat();
        yield return new WaitForSeconds(3/abilityHaste.totalStat());
        cooldownOn = false;
    }
}