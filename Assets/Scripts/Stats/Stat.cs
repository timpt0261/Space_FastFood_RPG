using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat{

    [SerializeField]
    private int baseValue;
    
    // list of mods from armor, items, skills, etc.
    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(mod => finalValue += mod);
        return finalValue;
    }

    public void SetValue(int value) {
        baseValue = value;
    }

    public void AddModifier (int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }
}
