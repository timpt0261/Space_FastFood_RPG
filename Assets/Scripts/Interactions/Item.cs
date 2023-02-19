using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Can be consuable, buff, or weapon

    [SerializeField] private int _idItem;
    [SerializeField] private string _name;

    private void Awake()
    {
        _idItem = Random.RandomRange(0, 2);
        switch (_idItem) 
        {
            case 0:
                _name = "Consumable";
                break;
            case 1:
                _name = "Buff";
                break;
            case 2:
                _name = "Weapon";
                break;

        }
    }



}
