using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum VampireType
{
    Melee,
    Range,
    Flying,
}

public enum VampireElementalType
{
    None,
    Fire,
    Ice,
}

public abstract class VampireObject : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    
    [TextArea(15, 20)]
    [SerializeField] private string description;
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private Time spawnTime;
    [SerializeField] private float visibleRadius;
    [SerializeField] private VampireElementalType elemental;

    protected VampireType type;  
}
