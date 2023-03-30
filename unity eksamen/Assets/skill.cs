using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill : playerSkills
{
    public string skillName;
    public Button button;
    public string description;
    public int price;
    public bool isActive;
    public bool buyable = false;
    public List<skill> nextSkills = new List<skill>();
    public skill(int x, string skillname, List<skill> _nextSkills, string des)
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
        skillName = skillname;
        description=des;
    }

    public skill(int x, string skillname, string des)
    {
        nextSkills = null;
        price = x;
        isActive = false;
        skillName = skillname;
        description=des;
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
                    if(!skill.isActive){
                    skill.buyable = true;
                    skill.button.interactable = true;
                    skill.button.GetComponentInParent<buttonScript>().changeImg(1);
                    }
                }
            }
            button.interactable=false;

            button.GetComponentInParent<buttonScript>().changeImg(2);
            updateSkills(this.skillName);
            return true;
        }
        else return false;
    }

}