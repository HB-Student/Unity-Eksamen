using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonScript : MonoBehaviour
{
    public List<Sprite> images=new List<Sprite>();
    public string text;

    public void changeImg(int image){
        gameObject.GetComponent<Image>().sprite=images[image];
    }

    public void displayDescription(){
        gameObject.GetComponentInChildren<Text>().text = text;
    }
    public void hideDescription(){
        gameObject.GetComponentInChildren<Text>().text = "";
    }
}
