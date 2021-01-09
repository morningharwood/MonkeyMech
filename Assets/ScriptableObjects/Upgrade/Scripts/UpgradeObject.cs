using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum UpgradeType
{
    PrimaryHand,
    SecondaryHand,
    Skill,
}

public enum UpgradeLifetime
{
    Persistant,
    Consumable,
};

public abstract class UpgradeObject : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    protected UpgradeType type;
    [TextArea(15, 20)]
    [SerializeField] private string description;
    [SerializeField] private int cost;
    [SerializeField] private UpgradeLifetime lifetime;
    [SerializeField] private List<LootObject> lootRequired;
}
