using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Secondary Hand Object", menuName = "Upgrade System/Secondary Hand")]
public class SecondaryHandObject : UpgradeObject
{
    public void Awake()
    {
        type = UpgradeType.SecondaryHand;
    }
}
