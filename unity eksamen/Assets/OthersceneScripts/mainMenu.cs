using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playButton(){
        SceneManager.LoadScene(1);
    }
    
    public void quitButton(){
        Debug.Log("quit");
        Application.Quit();
    }
}
