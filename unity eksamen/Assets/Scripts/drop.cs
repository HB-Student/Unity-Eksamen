using UnityEngine;

public class drop : MonoBehaviour
{
    public int dropChance;
    public int value;
    public drop(int c, int v)
    {
        dropChance = c;
        value = v;
    }
}
