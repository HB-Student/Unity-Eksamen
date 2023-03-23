using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skillTree : MonoBehaviour
{
    public GameObject skillTreePanel;
    public GameObject skillTreeButton;
    void start(){

    }

    void update(){

    }

    public void showTree(){
        skillTreePanel.SetActive(true);
        skillTreeButton.SetActive(false);
    }
    public void hideTree(){
        skillTreePanel.SetActive(false);
        skillTreeButton.SetActive(true);
    }
}