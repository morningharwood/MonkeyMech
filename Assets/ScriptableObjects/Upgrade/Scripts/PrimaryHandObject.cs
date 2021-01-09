using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipType
{
    None,
    Light,
    Dark,
    Grapple,
}

public enum ChainType
{
    None,
    Distance,
    Damage,
}


[CreateAssetMenu(fileName = "New Primary Hand Object", menuName = "Upgrade System/Primary Hand")]
public class PrimaryHandObject : UpgradeObject
{
    [SerializeField] private TipType tip;
    [SerializeField] private ChainType chain; 
    public void Awake()
    {
        type = UpgradeType.PrimaryHand;
    }
}
