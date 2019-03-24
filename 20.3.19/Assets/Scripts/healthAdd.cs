using UnityEngine;

public class healthAdd : MonoBehaviour
{
    public PlayerHealth player;
    public static healthAdd healthAdder;
    private void Awake()
    {
        healthAdder = this;
    }
    public void Add (int toAdd)
    {
        player.health += toAdd;
    }
}
