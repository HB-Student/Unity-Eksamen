using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSystem
{

public event EventHandler onExperienceChange;
public event EventHandler onLevelChange;
public event EventHandler onTokenChange;
private int level;
private int exp;
private int expToNextLevel;
public int usableTokens; 
public levelSystem(){
    level=0;
    exp=0;
    expToNextLevel=100;
    usableTokens=0;
}

public void addExp(int amoutToAdd){
    exp+=amoutToAdd;
    while(exp>=expToNextLevel){
        level++;
        exp-=expToNextLevel;
        usableTokens++;
        if(onTokenChange !=null) onTokenChange(this, EventArgs.Empty);
        if(onLevelChange !=null) onLevelChange(this, EventArgs.Empty);
    }
        if(onExperienceChange !=null) onExperienceChange(this, EventArgs.Empty);
    }
public int getLevel(){
return level;
}
public int getTokens(){
return usableTokens;
}

public void removeTokens(int amount){
    usableTokens-=amount;
    if(onTokenChange !=null) onTokenChange(this, EventArgs.Empty);
}

public float getExperienceToSlider(){
    return (float)exp / (float)expToNextLevel;
}
}
