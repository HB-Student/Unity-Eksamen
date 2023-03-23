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
            doing = action.Move;
        }
    }
}