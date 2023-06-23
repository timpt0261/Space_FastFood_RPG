using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   
    private Dictionary<string, Item> inventory;
    private int currentCapacity { get; set; }
    private int maxCapacity;

    public Inventory( int startingCapacity, int startingMaxCapacity)
    {
        inventory = new Dictionary<string, Item>(startingMaxCapacity);
        currentCapacity = startingCapacity;
        maxCapacity = startingMaxCapacity;
    }

    public bool AddItem(Item item , int amount = 1)
    {
        if (inventory.Count >= currentCapacity)
        {
            Debug.Log("Inventory is full!");
            return false;
        }

        string itemName = item.itemName;
        if (!HasItem(itemName))
        {
            inventory.Add(itemName, item);
            return true;
        }

        inventory[itemName].Amount(amount);

        Debug.Log("Added item: " + item.itemName + " to the inventory.");
        return true;
    }

    public bool HasItem(string itemName)
    {
        return inventory.ContainsKey(itemName);
    }

    public bool RemoveItem(Item item)
    {
        string itemName = item.itemName;
        if (inventory.ContainsKey(itemName))
        {
            inventory.Remove(itemName);
            Debug.Log("Removed item: " + item.itemName + " from the inventory.");
            return true;
        }

        Debug.Log("Item: " + item.itemName + " not found in the inventory.");
        return false;
    }

    public void UseItem(Item item)
    {
        // Implement the logic for using the item
        // This can involve applying effects, modifying stats, etc.
        Debug.Log("Using item: " + item.itemName);
        // Add your item usage logic here

        inventory[item.itemName].Use();
    }

    public void StolenItem(Item item)
    {
        // Implement the logic for handling stolen items
        // This can involve removing the item from the inventory or modifying its properties
        Debug.Log("Item: " + item.itemName + " was stolen!");
        // Add your stolen item logic here
    }

    public void SellItem(Item item)
    {
        // Implement the logic for selling items
        // This can involve removing the item from the inventory and providing currency or rewards
        Debug.Log("Sold item: " + item.itemName);
        // Add your selling item logic here
    }

    public void ExchangeItem(Item item, Item newItem)
    {
        // Implement the logic for exchanging items
        // This can involve removing the old item from the inventory and adding the new item
        Debug.Log("Exchanged item: " + item.itemName + " with: " + newItem.itemName);
        // Add your item exchange logic here
    }

    public void IncreaseCapacity(int increment)
    {
        currentCapacity += increment;
        if (currentCapacity > maxCapacity)
            currentCapacity = maxCapacity;

        Debug.Log("Inventory capacity increased to: " + currentCapacity);
    }

    public void DecreaseCapacity(int decrement)
    {
        currentCapacity -= decrement;
        if (currentCapacity < 0)
            currentCapacity = 0;

        Debug.Log("Inventory capacity decreased to: " + currentCapacity);
    }
}
