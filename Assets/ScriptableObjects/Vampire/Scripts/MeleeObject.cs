using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Vampire Object", menuName = "Vampire System/Melee")]
public class MeleeObject : VampireObject
{
    public void Awake()
    {
        type = VampireType.Melee;
    }
}
