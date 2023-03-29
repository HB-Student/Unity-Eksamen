using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class archerBranch : branch
{
    public skill archer1;
    public skill archer2;
    public skill archer3;
    public skill archer4;

    // Start is called before the first frame update
    void Start()
    {
        archer4 = new skill(40, "archer3", "add 4x range to archer");
        archer3 = new skill(30, "archer2", new List<skill>() { archer4 },"add 3x range");
        archer2 = new skill(20, "archer1", new List<skill>() { archer3 }, "Add 2x agility");
        archer1 = new skill(10, "archer", new List<skill>() { archer2 }, "enable archers"); archer1.buyable = true;
        skills.Add(archer1);
        skills.Add(archer2);
        skills.Add(archer3);
        skills.Add(archer4);

        fakeStart();
        archer1.button.interactable = true;
    }



}

