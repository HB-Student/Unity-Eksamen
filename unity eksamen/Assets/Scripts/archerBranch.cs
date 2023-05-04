using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class archerBranch : branch
{
    public skill warrior1;
    public skill warrior2;
    public skill warrior3;
    public skill warrior4;

    // Start is called before the first frame update
    void Start()
    {
        warrior4 = new skill(4, "warrior3", "Make warrior attack faster");
        warrior3 = new skill(3, "warrior2", new List<skill>() { warrior4},"Make warrior attack faster");
        warrior2 = new skill(2, "warrior1", new List<skill>() { warrior3}, "Make warrior move faster");
        warrior1 = new skill(1, "warrior", new List<skill>() { warrior2 }, "Make warrior stronger"); warrior1.buyable = true;
        skills.Add(warrior1);
        skills.Add(warrior2);
        skills.Add(warrior3);
        skills.Add(warrior4);

        fakeStart();    
        }



}

