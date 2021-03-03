// ---- J A C K - R A N D O L P H ---- \\
// ---- 2 0 2 1 - ALL RIGHTS RESERVED  \\
// -- PURPOSE : Key init. -- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCore : MonoBehaviour
{

    #region Variables

    [ Tooltip( "Key code SO" ) ]
    public KeyCode keyCode;

    #endregion

    private void Start()
    { // On init
        
        if ( keyCode == null )
        { // If no key code object attatched

            Debug.Log( "No key code attatched to key: " + this.name );
            Destroy( this.gameObject );

        }

        if ( !this.CompareTag( "Key" ) )
        { // If incorrect tag

            Debug.Log( "Incorrect tag on key: " + this.name );
            Destroy( this.gameObject );

        }

    }

}
