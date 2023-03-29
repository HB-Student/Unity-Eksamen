using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class playerSkills
{
    public void updateSkills(string name)
    {
        switch (name)
        {
            case "archer":

                Debug.Log("Updated archer");
                break;
            case "archer1":
				Debug.Log("Updated archer 1");
                break;
            case "archer2":
				Debug.Log("Updated archer 2");
                break;
            case "archer3":
				Debug.Log("Updated archer 3");
                break;
            case "wizard":
				Debug.Log("Updated wizard ");
                break;
            case "wizard1":
				Debug.Log("Updated wizard 1");
                break;
            case "wizard2":
				Debug.Log("Updated wizard 2");
                break;
            case "wizard3":
				Debug.Log("Updated wizard 3");
                break;
            case "orb":
				Debug.Log("Updated orb ");
                break;
            case "orb1":
				Debug.Log("Updated orb 1");
                break;
            case "orb2":
				Debug.Log("Updated orb 2");
                break;
            case "orb3":
				Debug.Log("Updated orb 3");
                break;
            default:
                return;
        }
    }
}
