using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardBullet : scanners
{
    public GameObject target;
    public int speed;
    public int damage;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,0.01f*speed);
        List<GameObject> enemies = scanList("monster",transform.localScale.x);
        if (enemies.Count>=1){
            foreach (var enemy in enemies)
            {
                enemy.gameObject.GetComponent<monster>().takeDamage(damage);
            }
            Destroy(gameObject);
        } else if (transform.position == target.transform.position)
        {
            Destroy(gameObject);
        }
    }
}
