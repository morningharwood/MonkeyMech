// ---- J A C K - R A N D O L P H ---- \\
// ---- 2 0 2 1 - ALL RIGHTS RESERVED  \\
// -- PURPOSE : Creates coin asset. -- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Libraries
// NONE

// Requirements
// NONE

[CreateAssetMenu(menuName = "coin/create/coinAsset")]
public class CoinsAsset : ScriptableObject
{

    [Tooltip("The coin prefeb OR gameObject.")]
    public GameObject coinMesh; // Mesh of coin

    [Space(10)]

    [Tooltip("How much the coin is worth.")]
    public float worth = 10.0f; // How much the coin is worth

}
