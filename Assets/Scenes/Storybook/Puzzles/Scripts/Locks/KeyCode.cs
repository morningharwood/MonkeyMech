// ---- J A C K - R A N D O L P H ---- \\
// ---- 2 0 2 1 - ALL RIGHTS RESERVED  \\
// -- PURPOSE : Creates key and lock code asset. -- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Key/create/key")]
public class KeyCode : ScriptableObject
{

    #region Variables

    [ Tooltip( "Code to unlock lock" ) ]
    public int code = 1111;

    [ Tooltip( "Dev note for what key unlocks" ) ]
    public string keyDescription = "Description";

    #endregion

}
