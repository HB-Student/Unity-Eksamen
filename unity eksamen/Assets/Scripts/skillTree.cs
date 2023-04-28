using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skillTree : MonoBehaviour
{
    public GameObject skillTreePanel;

    public void showTree(){
        skillTreePanel.SetActive(true);
    }
    public void hideTree(){
        skillTreePanel.SetActive(false);
    }
}