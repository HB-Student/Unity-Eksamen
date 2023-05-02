using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class buyMenu : MonoBehaviour
{
    public GameObject buyButtonPrefab;
    private TextMeshProUGUI money;
    // Start is called before the first frame update
    void Start()
    {
        money=GameObject.Find("moneyDisplay").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMoney(int amount){
        money.SetText("Money: "+ amount.ToString());
    }
    public void setButtons(List<hero> heroes){
        foreach (var item in heroes)
        {
        GameObject button = Instantiate(buyButtonPrefab, new Vector3(0,0,0), Quaternion.identity);
        button.GetComponent<buyButton>().setHero(item);
		button.GetComponent<buyButton>().transform.SetParent(GameObject.Find("buttons").transform);
        }
    }
}
