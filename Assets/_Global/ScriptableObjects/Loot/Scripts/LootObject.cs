using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LootType
{
    Chest,
    Bag,
    Coin,
    Crystal,
}

public abstract class LootObject : ScriptableObject
{
    public GameObject prefab;
    public LootType type;
    [TextArea(15, 20)]
    public string description;
}
