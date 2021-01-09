using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Range Vampire Object", menuName = "Vampire System/Range")]
public class RangeObject : VampireObject
{
    public void Awake()
    {
        type = VampireType.Range;
    }
}
