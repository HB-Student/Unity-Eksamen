using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbOfLight : MonoBehaviour
{
    public int maxHealth=100;
    public int currentHealth;

    public HealtbarScript healthbar;
    public int level =100;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth=maxHealth;
        healthbar.setMax(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(1);
        }        
    }
    void TakeDamage(int damage){
        currentHealth-=damage;
        healthbar.setHealth(currentHealth);
    }
}
