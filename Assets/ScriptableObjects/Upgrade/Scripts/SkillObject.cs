using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill Object", menuName = "Upgrade System/Skill")]
public class SkillObject : UpgradeObject
{
    public void Awake()
    {
        type = UpgradeType.Skill;
    }
}
