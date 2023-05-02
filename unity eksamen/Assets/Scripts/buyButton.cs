using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class buyButton : MonoBehaviour
{
private hero hero;
public string text;
public string price;

public TextMeshProUGUI textComp;
public TextMeshProUGUI priceComp;

void Start(){
    priceComp=GameObject.Find("buyPrice").GetComponent<TextMeshProUGUI>();
    textComp=GameObject.Find("buyDescription").GetComponent<TextMeshProUGUI>();
}

public void setHero(hero hero){
    this.hero=hero;
    this.price=hero.price.ToString();
    this.text=hero.text;
    gameObject.GetComponent<Button>().onClick.AddListener(() => this.buyHero(hero.name));
    EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
    if (trigger == null)
    {
        trigger = gameObject.AddComponent<EventTrigger>();
    }

    EventTrigger.Entry entry = new EventTrigger.Entry();
    entry.eventID = EventTriggerType.PointerEnter;
    entry.callback.AddListener((data) => { displayDescription(); });

    // Add the entry to the EventTrigger component
    trigger.triggers.Add(entry);

    entry = new EventTrigger.Entry();
    entry.eventID = EventTriggerType.PointerExit;
    entry.callback.AddListener((data) => { hideDescription(); });

    // Add the entry to the EventTrigger component
    trigger.triggers.Add(entry);

}

public void displayDescription(){
		textComp.SetText(text);
		priceComp.SetText("Price: "+price.ToString());
    }
    public void hideDescription(){
        textComp.text="";
		priceComp.text="";
    }

public void buyHero(string ts){
    string heroToBuy;
    switch (ts)
		{
			case "wizard (hero)":
				heroToBuy = "wizard";
				break;
			default:
				return;
		}
    GameObject.Find("GameManager").GetComponent<gameManager>().buyHero(heroToBuy);
}
}
