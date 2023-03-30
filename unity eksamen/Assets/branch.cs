using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class branch : MonoBehaviour
{
    public List<Sprite> buttonImages;
    public gameManager1 gameManager;
    public GameObject buttonPrefab;
    public List<skill> skills = new List<skill>();

    public List<GameObject> buttons = new List<GameObject>();

    public void fakeStart(){
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager1>();
        Debug.Log("gamemanager");
        for (int i = 0; i < skills.Count; i++)
        {
            int index = i;
            buttons.Add((Instantiate(buttonPrefab)));
            buttons[i].GetComponent<buttonScript>().images=buttonImages;
            buttons[i].GetComponent<buttonScript>().changeImg(0);
            buttons[i].GetComponent<buttonScript>().text=skills[i].description;
            buttons[i].transform.SetParent(gameObject.transform);
            buttons[i].GetComponent<Button>().onClick.AddListener(() => activate_skill(index));
            skills[i].button = buttons[i].GetComponent<Button>();
            }
            createBtn();
    }
    public void activate_skill(int skillToAdd)
    {
        skill skillToActivate = skills[skillToAdd];
        if (skillToActivate.price <= gameManager.levelSys.getTokens())
        {
            if (skillToActivate.activate())
            {
                gameManager.levelSys.removeTokens(skillToActivate.price);
            };
        }

    }
    private void createBtn(){
        Button tempBtn =skills[0].button;
        buttonScript tempScript=skills[0].button.GetComponentInParent<buttonScript>();
        tempBtn.interactable=true;
        tempScript.changeImg(1);
    }
}
