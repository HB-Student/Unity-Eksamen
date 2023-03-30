using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sliderScript : MonoBehaviour
{
    public float max=150f;
    public float min = 0f;
    public float sliderVal=0f;
    public Slider slider; 
    // Start is called before the first frame update
    void Start()
    {
     slider=gameObject.GetComponent<Slider>();   
    }

    // Update is called once per frame
    void Update()
    {
        slider.value=sliderVal;
        sliderVal+=0.001f;
    }
}
