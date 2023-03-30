using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject marker;
    
    void Start(){
        Instantiate(marker,transform.position,Quaternion.identity);
    }
}
