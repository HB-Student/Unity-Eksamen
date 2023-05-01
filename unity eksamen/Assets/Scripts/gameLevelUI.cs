using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameLevelUI : MonoBehaviour 
{
    private Animation anim;
    public Text textElement;
    public Button buttonElement;
    public float fadeSpeed = 0.5f;

    void Start(){
        anim = textElement.gameObject.GetComponent<Animation>();
    }

    public void endLevel(){
         Color fixedColor = textElement.color;
        fixedColor.a = 0;
        textElement.color = fixedColor;
        textElement.text="Wave over";
        anim.Play("fadeIn");
        buttonElement.gameObject.SetActive(true);
    }

    public void startLevel(level levelToStart){
        Color fixedColor = textElement.color;
        fixedColor.a = 0;
        textElement.color = fixedColor;

        textElement.text="Wave "+levelToStart.levelNum;
        anim.Play("fadeIn");
        buttonElement.gameObject.SetActive(false);
    }


}