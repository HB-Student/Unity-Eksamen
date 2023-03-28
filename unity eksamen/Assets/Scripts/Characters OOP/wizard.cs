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
                    if (startTime + 3 / abilityHaste.totalStat() - Time.time <= 0)
                    {
                        GameObject magicBall = Instantiate(projectile,transform.position,Quaternion.identity);
                        magicBall.GetComponent<wizardBullet>().target = enemy;
                        magicBall.GetComponent<wizardBullet>().damage = 10*strength.totalStat();
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