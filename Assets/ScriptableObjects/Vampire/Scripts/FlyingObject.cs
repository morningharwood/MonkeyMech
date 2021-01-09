using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Flying Vampire Object", menuName = "Vampire System/Flying")]
public class FlyingObject : VampireObject
{
    public void Awake()
    {
        type = VampireType.Flying;
    }
}
