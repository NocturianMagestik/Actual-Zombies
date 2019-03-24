using UnityEngine;
[CreateAssetMenu(fileName = "Health Potion", menuName = "Inventory/Health Potion")]
public class healthPotion : Item
{
    
    public int healAmount = 2;
    // Start is called before the first frame update
    void Awake()
    {
        hasBeenPicked = false;
    }
    // Update is called once per frame
    public override void Use()
    {
        healthAdd.healthAdder.Add(healAmount);
        Debug.Log("Potion used");
        base.Use();
        Debug.Log("Potion completely used");

    }
}
