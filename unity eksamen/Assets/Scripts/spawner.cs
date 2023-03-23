using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public List<GameObject> monsterTypes = new List<GameObject>();
    public List<GameObject> heros = new List<GameObject>();

    void Start()
    {
        foreach (var monster in monsterTypes)
        {
            Vector2 randomSpawnPos = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
            Instantiate(monster, randomSpawnPos, Quaternion.identity);
        }
        foreach (var hero in heros)
        {
            Vector2 randomSpawnPos = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            Instantiate(hero, randomSpawnPos, Quaternion.identity);
        }
    }
}
