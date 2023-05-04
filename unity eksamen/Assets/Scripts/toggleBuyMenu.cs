using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleBuyMenu : MonoBehaviour
{
    private bool isActive=false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(pause(2));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(!isActive){
                transform.GetChild(0).gameObject.SetActive(true);
                isActive=true;
            }else{
                transform.GetChild(0).gameObject.SetActive(false);
                isActive=false;
            }
            }
    }
    
    IEnumerator pause(float sec){
        yield return new WaitForEndOfFrame();
        transform.GetChild(0).gameObject.SetActive(false);
        isActive=false;
    }
    

}
