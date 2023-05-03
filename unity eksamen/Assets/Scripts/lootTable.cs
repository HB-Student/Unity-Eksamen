using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootTable : MonoBehaviour
{
    public List<GameObject> slimeDrops = new List<GameObject>();

    public List<GameObject> goblinDrops = new List<GameObject>();
    
    public List<GameObject> getTable(string type)
    {
        switch (type)
        {
            case "slime":
                return slimeDrops;
            case "goblin":
                return goblinDrops;
            default:
                return new List<GameObject>();
        }
    }
}
