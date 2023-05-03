using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class playerSkills
{

    private characterManager charMan;
    private killZone orbScript;
    public void updateSkills(string name)
    {
        switch (name)
        {
            case "warrior":
                charMan.bonusStat("abilityHaste",1);
                break;
            case "warrior1":
                charMan.bonusStat("abilityHaste",1);
                break;
            case "warrior2":
				charMan.bonusPercentage("agility",50);
                break;
            case "warrior3":
				charMan.bonusPercentage("strength",50);
                break;   
            case "wizard":
				charMan.bonusStat("abilityHaste",1);
                break;
            case "wizard1":
                charMan.bonusStat("agility",5);
                break;
            case "wizard2":
                charMan.bonusStat("strength",1);
                break;
            case "wizard3":
                charMan.bonusStat("abilityHaste",3);
                break;
            case "orb":
                orbScript.setActive(true);
                orbScript.update();
                break;
            case "orb1":
				orbScript.setCooldownTime(1.0f);
                orbScript.update();
                break;
            case "orb2":
				orbScript.setRange(4.0f);
                orbScript.update();
                break;
            case "orb3":
				orbScript.setCooldownTime(0.7f);
                orbScript.update();
                break;
            case "scavenger":
                charMan.bonusStat("agility",1);
                break;
            case "scavenger1":
                charMan.bonusPercentage("agility",50);
				
                break;
            case "scavenger2":
                charMan.bonusPercentage("agility",50);
				
                break;
            case "scavenger3":
                charMan.bonusStat("agility",3);
				
                break;
            default:
                return;
        }
    }

    public void setCharMan(characterManager characterManager){
        charMan=characterManager;
    }
    public void setOrb(killZone killZone){
        orbScript = killZone;
    }
}
