using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour
{
    public GameObject target;
    public int speed;
    public int damage;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,0.01f*speed);
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "monster"){
            other.gameObject.GetComponent<monster>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
