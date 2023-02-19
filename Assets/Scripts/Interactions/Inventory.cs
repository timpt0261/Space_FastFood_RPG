using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Dictionary to hold the items in the inventory
    private Dictionary<string, int> items = new Dictionary<string, int>();

    // Add an item to the inventory
    public void AddItem(string itemName, int amount)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName] += amount;
        }
        else
        {
            items[itemName] = amount;
        }
    }

    // Remove an item from the inventory
    public void RemoveItem(string itemName, int amount)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName] -= amount;
            if (items[itemName] < 0)
            {
                items[itemName] = 0;
            }
        }
    }

    // Check if the inventory contains an item
    public bool HasItem(string itemName)
    {
        return items.ContainsKey(itemName);
    }

    // Get the number of a particular item in the inventory
    public int GetItemAmount(string itemName)
    {
        if (items.ContainsKey(itemName))
        {
            return items[itemName];
        }
        else
        {
            return 0;
        }
    }
}
