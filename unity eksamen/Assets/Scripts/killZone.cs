using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class killZone : MonoBehaviour
{
    private bool cooldown;
    private GameObject currentMonster;
    private int damage;
    private float coolDownTime;
    private float range;
    private bool active;
    public LineRenderer lineRenderer;
    public float lineWidth = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        active=false;
        cooldown=false;
        coolDownTime=1.5f;
        damage=1;
        range=3f;

        if(lineRenderer==null){
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
         // Initialize the line renderer
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

    public void setCooldownTime(float amount){
        coolDownTime=amount;
    }
    public void setDamage(int amount){
        damage=amount;
    }
    public void setRange(float amount){
        range=amount;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag=="monster" && active){
            if(!cooldown){
                col.GetComponent<monster>().takeDamage(damage);
                DrawLineTo(col.gameObject);
                StartCoroutine(SetCooldown());
            }
        }
    }
    public void setActive(bool state){
        active=state;
    }
        IEnumerator SetCooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(coolDownTime);
        cooldown = false;
    }
    

        void DrawLineTo(GameObject target)
    {
        // Set the start and end points of the line renderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, target.transform.position);

        // Enable the line renderer
        lineRenderer.enabled = true;

        // Disable the line renderer after 1 second
        Invoke("DisableLineRenderer", 0.2f);
    }

    void DisableLineRenderer()
    {
        lineRenderer.enabled = false;
    }

    public void print(string ts){
        Debug.Log(ts);
    }

    internal void update()
    {
        transform.parent.GetComponent<Animation>().Play("heroLevelUp");
    }
}
