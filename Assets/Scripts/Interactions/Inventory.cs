using System;
using System.Generics;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
    [SerializeField] private Dictionary<int, string>  _inventory;
}