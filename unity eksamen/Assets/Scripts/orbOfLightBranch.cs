using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class orbOfLightBranch : branch
{
    public skill orb1;
    public skill orb2;
    public skill orb3;
    public skill orb4;

    // Start is called before the first frame update
    void Start()
    {
        orb4 = new skill(4, "orb3", "Shorten Cooldowntim");
        orb3 = new skill(3, "orb2", new List<skill>() { orb4 }, "More range");
        orb2 = new skill(2, "orb1", new List<skill>() { orb3 }, "Less cooldowntime on the ligtning");
        orb1 = new skill(1, "orb", new List<skill>() { orb2 }, "the orb can shoot lasers"); orb1.buyable = true;
        skills.Add(orb1);
        skills.Add(orb2);
        skills.Add(orb3);
        skills.Add(orb4);

        fakeStart();
    }



}


