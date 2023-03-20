using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public List<GameObject> monsterTypes = new List<GameObject>();

    void Start()
    {
        StartCoroutine(gameStart());
    }

    IEnumerator gameStart(){
        GameObject monster = Instantiate(monsterTypes[0],transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1f);
        print("Spawned: " + monster.name);
    }
}
