using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class branch : MonoBehaviour
{
    private int evolutionPoints=15;
    public GameObject buttonPrefab;
    public List<skill> skills = new List<skill>();

    public List<GameObject> buttons = new List<GameObject>();

    public void fakeStart(){
        for (int i = 0; i < skills.Count; i++)
        {
            int index = i;
            buttons.Add((Instantiate(buttonPrefab)));
            buttons[i].transform.SetParent(gameObject.transform);
            buttons[i].GetComponent<Button>().onClick.AddListener(() => activate_skill(index));
            skills[i].button = buttons[i].GetComponent<Button>();
        }
    }
    public void activate_skill(int skillToAdd)
    {
        skill skillToActivate = skills[skillToAdd];
        if (skillToActivate.price <= evolutionPoints)
        {
            if (skillToActivate.activate())
            {
                evolutionPoints += 20;
            };
        }

    }
}
