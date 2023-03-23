public abstract class hero : character
{
    public int mana;

    public override void decide()
    {
        if (scanBool("monster", sightRadius))
        {
            doing = action.combat;
        }
        else
        {
            if (doing != action.Move)
            {
                doing = action.Idle;
            }
        }
    }
}