using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public float[] playerPosition;
    public int health;
    public string[] items;
    public string[] tiles;

    public SaveData (PlayerController player, PlayerHealth healthControl, InventoryUI inventory)
    {
        health = healthControl.health;
        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;

    }
}
