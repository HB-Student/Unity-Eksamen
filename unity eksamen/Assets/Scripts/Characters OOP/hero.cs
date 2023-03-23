using UnityEngine;

public abstract class hero : character
{
    public int mana;

    public override void decide()
    {
        if (Vector2.Distance(transform.position, target.transform.position) <= 0.75f){
            target.transform.position = transform.position;
            if (scanBool("monster", sightRadius))
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
}