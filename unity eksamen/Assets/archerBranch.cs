using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts

public class archerBranch : branch
{
    public skill archer1 = new skill(10, "get archer"); 
    public skill archer2 = new skill(20, "extend range"); 
    public skill archer3 = new skill(30, "add damage"); 
    public skill archer4 = new skill(40, "Fireball, du du du dudet duh - Pitbull"); 
    public int mana = 15;
    public List<skill> skills= new List<skill>();
    public List<skill> unActiveSkills= new List<skill>();
    public List<skill> activeSkills= new List<skill>();
    
    public List<GameObject> buttons = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        skills.Add(archer1);
        skills.Add(archer2);
        skills.Add(archer3);
        skills.Add(archer4);
        unActiveSkills.Add(archer1);
        unActiveSkills.Add(archer2);
        unActiveSkills.Add(archer3);
        unActiveSkills.Add(archer4);
        string tagToFind = "button"; // The tag of the GameObjects you want to find
        Transform parentTransform = transform; // The parent transform whose children will be iterated through
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Transform childTransform = parentTransform.GetChild(i); // Get the child transform at index i
            GameObject childGameObject = childTransform.gameObject; // Get the child GameObject from the child transform
            if (childGameObject.CompareTag(tagToFind)) // Check if the child GameObject has the specified tag
            {
                buttons.Add(childGameObject); // Add the child GameObject to the list if it has the specified tag
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}



public class skill{
    public string name;
    public string description;
    public int price;
    public bool isActive;
    public skill(int x, string k){
        price=x;
        isActive=false;
        name=k;
    }
    public void activate(){
        isActive=true;
        Debug.Log(name);
    }
}