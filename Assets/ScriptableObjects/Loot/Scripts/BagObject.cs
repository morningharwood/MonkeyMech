using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Bag Object", menuName = "Loot System/Loot/Bag")]
public class BagObject : LootObject
{
    public int lootValue;
    public void Awake()
    {
        type = LootType.Bag;
    }
}
