using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootTable : MonoBehaviour
{
    public List<GameObject> slimeDrops = new List<GameObject>();
    public List<int> slimeChances = new List<int>();
    
    public List<drop> getTable(string type)
    {
        List<drop> loot = new List<drop>();
        switch (type)
        {
            case "slime":
                for (int i = 0; i < slimeChances.Count; i++)
                {
                    loot.Add(new drop(slimeChances[i], slimeDrops[i]));
                }
                return loot;
            default:
                return loot;
        }
    }
}
