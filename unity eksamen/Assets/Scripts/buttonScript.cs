using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonScript : MonoBehaviour
{
    public List<Sprite> images=new List<Sprite>();
    private string text;
    private int price;
	private Text textComp;
	private Text priceComp;
	
    skill skill;
    branch branch;


    void Start(){
        priceComp=GameObject.Find("Price").GetComponent<Text>();
        textComp=GameObject.Find("Description").GetComponent<Text>();
    }
    public void changeImg(int image){
        gameObject.GetComponent<Image>().sprite=images[image];
    }

    public void displayDescription(){
		textComp.text=text;
		priceComp.text="Price: "+price.ToString();
    }
    public void hideDescription(){
        textComp.text="";
		priceComp.text="";
    }

    public void setSkillAndBranch(skill Skill, branch Branch, int index){
        skill = Skill;
        branch=Branch;
        text=skill.description;
        images=branch.buttonImages;
        changeImg(0);
        gameObject.GetComponent<Button>().onClick.AddListener(() => branch.activate_skill(index));
        skill.button = gameObject.GetComponent<Button>();
        price=skill.price;
        }

}
