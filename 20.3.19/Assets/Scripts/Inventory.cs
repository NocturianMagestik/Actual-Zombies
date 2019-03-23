using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    public int space = 18;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem && items.Count < 18)
        {
            items.Add(item);
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
            return true;
        }
        else
        {
            Debug.Log("Inventory full");
            return false;
        }
    }

    public void Remove (Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
