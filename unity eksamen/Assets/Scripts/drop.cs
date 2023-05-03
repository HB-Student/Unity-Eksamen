using UnityEngine;

public class drop
{
    public int dropChance;
    public GameObject item;
    public drop(int c, GameObject d)
    {
        dropChance = c;
        item = d;
    }
}
