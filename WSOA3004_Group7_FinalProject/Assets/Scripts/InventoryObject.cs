using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryObj", menuName = "InventoryObj")]
[System.Serializable]
public class InventoryObject : ScriptableObject
{
    public InventoryClass[] inven;
}