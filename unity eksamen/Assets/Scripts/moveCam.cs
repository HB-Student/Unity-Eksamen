using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class moveCam : MonoBehaviour
{
    public float zoom;
    // Start is called before the first frame update
    float camZ;
    void Start()
    {
        camZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        zoom = GetComponent<Camera>().orthographicSize;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        worldPosition = (worldPosition*5)/zoom;
        if(worldPosition.x>9){
            transform.position=new Vector3(transform.position.x+(worldPosition.x-9)*0.05f, transform.position.y,camZ);
        }
        if(worldPosition.x<-9){
            transform.position=new Vector3(transform.position.x-(worldPosition.x+9)*-0.05f, transform.position.y,camZ);
        }
        if(worldPosition.y>3.5f){
            transform.position=new Vector3(transform.position.x, transform.position.y+(worldPosition.y+3.5f)*0.005f,camZ);
        }
        if(worldPosition.y<-3.5f){
            transform.position=new Vector3(transform.position.x, transform.position.y-(worldPosition.y-3.5f)*-0.005f,camZ);
        }

        if(Input.GetKeyDown("space")){
            transform.position=new Vector3(0,0,camZ);
        }
        if( Input.GetAxis("Mouse ScrollWheel") > 0f && zoom>0.4){
            GetComponent<Camera>().orthographicSize-=0.1f;
        }
        if( Input.GetAxis("Mouse ScrollWheel") < 0f){
            GetComponent<Camera>().orthographicSize+=0.1f;
        }   
    }
}
