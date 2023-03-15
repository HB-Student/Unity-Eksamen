using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealtbarScript : MonoBehaviour
{
    public Slider slider;

    public void setMax(int max){
        slider.maxValue=max;
        slider.value=max;
    }
    public void setHealth(int health){
        slider.value=health;
    }
}
