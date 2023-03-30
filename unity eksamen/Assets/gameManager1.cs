using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager1 : MonoBehaviour
{
    public levelSystem levelSys;
    public levelsUI levelUI;

    public orbOfLight orbOfLight;
    void Awake()
    {
        levelSys = new levelSystem();
        levelUI.setLevelSystem(levelSys);
        orbOfLight.setLevelSystem(levelSys);
    }

    public void addExp(int amount){
        levelSys.addExp(amount);
    }
}