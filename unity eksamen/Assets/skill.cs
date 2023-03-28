using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill : playerSkills
{
    public string name;
    public Button button;
    public string description;
    public int price;
    public bool isActive;
    public bool buyable = false;
    public List<skill> nextSkills = new List<skill>();
    public skill(int x, string skillname, List<skill> _nextSkills)
    {
        if (_nextSkills[0] == null)
        {
            nextSkills = null;
        }
        else
        {
            nextSkills.AddRange(_nextSkills);
        }
        price = x;
        isActive = false;
        name = skillname;
    }

    public skill(int x, string skillname)
    {
        nextSkills = null;
        price = x;
        isActive = false;
        name = skillname;
    }

    public bool activate()
    {
        if (buyable)
        {
            isActive = true;
            if (nextSkills == null)
            {
            }
            else
            {
                foreach (var skill in nextSkills)
                {
                    skill.buyable = true;
                    skill.button.interactable = true;
                    skill.button.GetComponent<Image>().color = Color.blue;
                }
            }
            button.interactable=false;
            button.GetComponent<Image>().color = Color.green;
            updateSkills(this.name);
            return true;
        }
        else return false;
    }

}