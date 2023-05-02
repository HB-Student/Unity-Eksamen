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
        wizard4 = new skill(4, "wizard3","Add 3 abilityHaste");
        wizard3 = new skill(3, "wizard2", new List<skill>() { wizard4 }, "Add 1 to strength");
        wizard2 = new skill(2, "wizard1", new List<skill>() { wizard3 }, "Add 5 to agility");
        wizard1 = new skill(1, "wizard", new List<skill>() { wizard2 },  "Add 1 to abilityHaste"); wizard1.buyable = true;
        skills.Add(wizard1);
        skills.Add(wizard2);
        skills.Add(wizard3);
        skills.Add(wizard4);

        fakeStart();
        }



}

