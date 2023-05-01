using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbOfLight : MonoBehaviour
{
    private levelSystem levelSys;
    public GameObject levelParticle;
    public GameObject eatParticle;
    public int currentHealth;
    
    public skillTree skilleTree; 
    private Camera mainCam;
    
    // Start is called before the first frame update
    void Start()
    {
mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(1);
        }        
    DetectObjectWithRaycast();

    }
    // Start is called before the first frame update


    public void DetectObjectWithRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // perform actions on the clicked object here
                if(gameObject.name=="OrbOfLight"){
                    skilleTree.showTree();
                }
            }
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
