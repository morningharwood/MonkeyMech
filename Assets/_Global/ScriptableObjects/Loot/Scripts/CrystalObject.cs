using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Crystal Object", menuName = "Loot System/Loot/Crystal")]
public class CrystalObject : LootObject
{
    public void Awake()
    {
        type = LootType.Crystal;
    }
}
