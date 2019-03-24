using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public Item item;

    // Start is called before the first frame update
    
    // Update is called once per frame
    public void PickUp()
    {

        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp == true)
        {
            item.hasBeenPicked = true;
            Destroy(gameObject);
        }
    }
}
