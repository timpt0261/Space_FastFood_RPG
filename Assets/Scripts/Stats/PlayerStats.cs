using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // initialization
    void Start()
    {
        //when equipment or item is changed, change stats TODO
    }

    /*
    // temp Equipment used since I don't know if we have an equipment script yet
    void onEquipmentChange (Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            magicResist.addModifier(newItem.magicResistModifier);
            armor.addModifier(newItem.armorModifier);
            damage.addModifier(newItem.damageModifier);
            speed.addModifier(newItem.speedModifier);
        }
        
        if(oldItem != null)
        {
            magicResist.removeModifier(newItem.magicResistModifier);
            armor.removeModifier(newItem.armorModifier);
            damage.removeModifier(newItem.damageModifier);
            speed.removeModifier(newItem.speedModifier);
        }
    }
    */
}
