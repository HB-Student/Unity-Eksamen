using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbOfLight : MonoBehaviour
{
    private levelSystem levelSys;
    public GameObject levelParticle;
    public GameObject eatParticle;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {

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
        //healthbar.setHealth(currentHealth);
    }

    public void setLevelSystem(levelSystem levelSystem){
        levelSys=levelSystem;
        levelSystem.onLevelChange+=levelSystem_onLevelChange;
    }

    
    private void levelSystem_onLevelChange(object sender, System.EventArgs e){
        spawnParticleEffect(levelParticle);
    }

    private void spawnParticleEffect(GameObject particlePrefab){
            GameObject particleObject = Instantiate(particlePrefab, gameObject.transform.position, Quaternion.identity);
            ParticleSystem particleSystem = particleObject.GetComponent<ParticleSystem>();
            particleSystem.Play();

            // Destroy the particle system after it has finished playing
            Destroy(particleObject, particleSystem.main.duration);
    }

    public void eatMonster(int amount){
        levelSys.addExp(amount);
        spawnParticleEffect(eatParticle);
    }
}
