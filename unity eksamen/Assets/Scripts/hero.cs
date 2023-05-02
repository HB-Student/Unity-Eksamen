using UnityEngine;
using UnityEngine.UI;
public abstract class hero : character
{
    private Animation levelUpAnim;
    public int price;
    public string text;
    public override void decide()
    {
        if (Vector2.Distance(transform.position, target.transform.position) <= 0.75f){
            target.transform.position = transform.position;
            if (scanBool("monster", sightRadius.totalStat()))
            {
                doing = action.combat;
            }
            else
            {
                doing = action.Move;
            }
        }
        else
        {
            doing = action.Move;
        }
    }
    public override void dead(){
        Destroy(gameObject);
    }
}