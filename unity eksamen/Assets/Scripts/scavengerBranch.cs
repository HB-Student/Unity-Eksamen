using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class scavengerBranch : branch
{
    public skill scavenger1;
    public skill scavenger2;
    public skill scavenger3;
    public skill scavenger4;

    // Start is called before the first frame update
    void Start()
    {
        scavenger4 = new skill(4, "scavenger3","Add 3 agility");
        scavenger3 = new skill(3, "scavenger2", new List<skill>() { scavenger4 }, "Add 50% to agility");
        scavenger2 = new skill(2, "scavenger1", new List<skill>() { scavenger3 }, "Add 50% to agility");
        scavenger1 = new skill(1, "scavenger", new List<skill>() { scavenger2 },  "Add 1 to agility"); scavenger1.buyable = true;
        skills.Add(scavenger1);
        skills.Add(scavenger2);
        skills.Add(scavenger3);
        skills.Add(scavenger4);

        fakeStart();
        }



}

