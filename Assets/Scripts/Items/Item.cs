using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("General")]

    [SerializeField]
    public string itemName = "New Item";

    [SerializeField]
    private Sprite icon;

    [SerializeField]
    [TextArea]
     private string itemDescription = "New Description";

    [SerializeField]
    private bool HasValue = true;

    [SerializeField]
    private int itemValue { get; set; }

    [Header("Stacking")]
     private int itemMaxAmount = 8;
    private int itemAmount = 1;

    [Header("Modifiers")]
    private Dictionary<string, int> itemModifiers;
        
    public enum ItemType { Consumable, Weapon, Armor, Crafting, Quest, Miscellaneous };

    [Header("Type")]
    public ItemType itemType = ItemType.Consumable;

    // Additional properties or methods can be added as needed
    public Item(string name = "New Item", string description = "New Descriptioon",  bool hasValue = true, int value = 10 , int maxAmount = 32,  int amount = 1, Dictionary<string,int> modifiers = null, ItemType type = ItemType.Consumable)
    {
        if (amount > maxAmount)
            return;

        itemName = name;
        itemDescription = description;
        itemValue = hasValue ? value : 10;
        itemAmount = amount;
        itemType = type;
        modifiers = new Dictionary<string, int>();
    }

    public virtual void ChangeMaxAmount(int newMaxAmount) 
    {
        itemMaxAmount = newMaxAmount;


    }

    public virtual bool Amount(int value) {
        if (itemAmount >= itemMaxAmount)
            return false;

        itemAmount += value;
        return true;
    }

    public virtual void Use()
    {
        if(itemAmount < 1)
            return;
        

        switch (itemType)
        {
            case ItemType.Consumable:
                Consume();
                break;
            case ItemType.Weapon:
                EquipWeapon();
                break;
            case ItemType.Armor:
                EquipArmor();
                break;
            case ItemType.Crafting:
                break;
            case ItemType.Quest:
                break;
            case ItemType.Miscellaneous:
                break;
            default:
                break;
        }

        itemAmount--;
    }

    public virtual void Consume() 
    {       
        

    }

    public virtual void EquipWeapon()
    {


    }

    public virtual void EquipArmor()
    {


    }

}