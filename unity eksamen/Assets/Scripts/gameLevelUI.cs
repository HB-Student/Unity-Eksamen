using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameLevelUI : MonoBehaviour 
{
    public Text textElement;
    public Button buttonElement;
    public float fadeSpeed = 0.5f;

    void Start(){
        
    }

    public void endLevel(){
        textElement.text="level over";
        // and back over 500ms.
        textElement.CrossFadeAlpha(1.0f, 4f, false);
        // fade to transparent over 500ms.
        textElement.CrossFadeAlpha(0.0f, 3f, false);
        buttonElement.gameObject.SetActive(true);
    }

    public void startLevel(level levelToStart){
        textElement.text="level "+levelToStart.levelNum;
        // and back over 500ms.
        textElement.CrossFadeAlpha(1.0f, 4f, false);
        // fade to transparent over 500ms.
        textElement.CrossFadeAlpha(0.0f, 3f, false);
        buttonElement.gameObject.SetActive(false);
    }


}