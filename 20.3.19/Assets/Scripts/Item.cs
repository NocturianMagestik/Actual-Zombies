﻿using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public bool isDefaultItem = false;
    new public string name = "New Item";    // Name of the item
    public Sprite icon = null;              // Item icon
    public bool showInInventory = true;
    public bool hasBeenPicked = false;

    void Awake()
    {
        hasBeenPicked = false;
    }
    // Called when the item is pressed in the inventory
    public virtual void Use()
    {
        // Use the item
        // Something may happen
        Debug.Log("using item");
        RemoveFromInventory();
    }

    // Call this method to remove the item from inventory
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}
