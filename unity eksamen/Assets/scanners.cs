using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class scanners : MonoBehaviour
{
	public stat sightRadius = new stat();
    public GameObject enemy;

    public bool scanBool(string opponentTag, int colliderRadius)
    {
        Collider2D[] overlapCollider = Physics2D.OverlapCircleAll(transform.position, colliderRadius);
        for (int i = 0; i < overlapCollider.Length; i++)
        {
            if (overlapCollider[i].gameObject.tag == opponentTag)
            {
                enemy = overlapCollider[i].gameObject;
                return true;
            }
        }
        return false;
    }

    public List<GameObject> scanList(string scanningTag, float colliderRadius)
    {
        Collider2D[] overlapCollider = Physics2D.OverlapCircleAll(transform.position, colliderRadius);
        List<GameObject> enemies = new List<GameObject>();
        for (int i = 0; i < overlapCollider.Length; i++)
        {
            if (overlapCollider[i].gameObject.tag == scanningTag)
            {
                enemies.Add(overlapCollider[i].gameObject);
            }
        }
        return enemies;
    }
}