public abstract class hero : character
{
    public int wisdom;
    public int intelligence;
    public int mana;

    public override void decide()
    {
        if (enemyScan("monster", sightRadius))
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