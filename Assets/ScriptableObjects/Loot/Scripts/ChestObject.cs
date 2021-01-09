using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chest Object", menuName = "Loot System/Loot/Chest")]
public class ChestObject : LootObject
{
    public int lootValue;
    public void Awake()
    {
        type = LootType.Chest;
    }
}
