using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level 
{
public gameManager gm;
public int levelNum;

public levelState gameLevelState;
public Dictionary<string, int> monsters = new Dictionary<string, int>();

public gameLevelUI UiElement;
private int monstersLeft;

public level(int num,int numSlime =0, int numGoblins=0){
    gameLevelState=levelState.before;
    setGM();
    UiElement=gm.UiElement;
    levelNum=num;
    monsters.Add("slime", numSlime);
    monsters.Add("goblin", numGoblins);
    monstersLeft+=numSlime;
    monstersLeft+=numGoblins;
}

public void setGM(){
gm = GameObject.Find("GameManager").GetComponent<gameManager>();
}


public void startLevel(){
    foreach (KeyValuePair<string, int> kvp in monsters)
    {
     gm.spawnMonster(kvp.Key, kvp.Value);   
    }
    UiElement.startLevel(this);
    gameLevelState=levelState.current;
}

public void endLevel(){
    gameLevelState=levelState.over;
    UiElement.endLevel();
}

public void killMonster(){
    monstersLeft--;
    if(monstersLeft<=0){
        endLevel();
    }
}
public enum levelState{
    before,
    current,
    over
}
}