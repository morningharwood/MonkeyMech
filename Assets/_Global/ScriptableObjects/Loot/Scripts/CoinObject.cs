using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Coin Object", menuName = "Loot System/Loot/Coin")]
public class CoinObject : LootObject
{
    public int lootValue;
    public void Awake()
    {
        type = LootType.Coin;
    }
}
