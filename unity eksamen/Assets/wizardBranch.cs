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
        wizard4 = new skill(40, "wizard3", "Add 10X damage");
        wizard3 = new skill(30, "wizard2", new List<skill>() { wizard4 }, "Increase rate of fire");
        wizard2 = new skill(20, "wizard1", new List<skill>() { wizard3 }, "Will shot with purple");
        wizard1 = new skill(10, "wizard", new List<skill>() { wizard2 }, "Increase range for wizard"); wizard1.buyable = true;
        skills.Add(wizard1);
        skills.Add(wizard2);
        skills.Add(wizard3);
        skills.Add(wizard4);

        fakeStart();
        wizard1.button.interactable = true;
    }



}


