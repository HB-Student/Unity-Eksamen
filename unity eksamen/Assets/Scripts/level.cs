using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class level 
{
public gameManager gm;
public Dictionary<string, int> monsters = new Dictionary<string, int>();



public level(int numSlime =0, int numGoblins=0){
    setGM();
    monsters.Add("slime", numSlime);
    monsters.Add("goblin", numGoblins);
}

public void setGM(){
gm = GameObject.Find("GameManager").GetComponent<gameManager>();
}
public void startLevel(){
    
    foreach (KeyValuePair<string, int> kvp in monsters)
    {
    Debug.Log(kvp.Value);
     gm.spawnMonster(kvp.Key, kvp.Value);   
    }
}

}