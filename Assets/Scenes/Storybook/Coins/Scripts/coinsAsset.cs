// ---- J A C K - R A N D O L P H ---- \\
// ---- 2 0 2 1 - ALL RIGHTS RESERVED  \\
// -- PURPOSE : Creates coin asset. -- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "coin/create/coinAsset")]
public class coinsAsset : ScriptableObject
{

    [Tooltip("The coin prefeb OR gameObject.")]
    public GameObject coinMesh; // Mesh of coin

    [Space(10)]

    //[ Tooltip( "How commonly the coin spawns." ) ]
    //public float spawnRate = 100.0f; // How commonly the coin spawns

    [Tooltip("How much the coin is worth.")]
    public float worth = 10.0f; // How much the coin is worth

}
