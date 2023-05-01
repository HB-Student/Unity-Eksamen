using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class wizardBranch : branch
{
    public skill wizard1;
    public skill wizard2;
    public skill wizard3;
    public skill wizard4;

    // Start is called before the first frame update
    void Start()
    {


        wizard4 = new skill(4, "orb3", "You can now make sacrifices");
        wizard3 = new skill(3, "orb2", new List<skill>() { wizard4 }, "Add additinal 2x to exp earned by sacrifices");
        wizard2 = new skill(2, "orb1", new List<skill>() { wizard3 }, "The orb can now shot lightning");
        wizard1 = new skill(1, "orb", new List<skill>() { wizard2 }, "Add additinal 3x to exp earned by orb"); wizard1.buyable = true;
        skills.Add(wizard1);
        skills.Add(wizard2);
        skills.Add(wizard3);
        skills.Add(wizard4);

        fakeStart();
        }



}

