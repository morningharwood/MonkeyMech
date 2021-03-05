// ---- J A C K - R A N D O L P H ---- \\
// ---- 2 0 2 1 - ALL RIGHTS RESERVED  \\
// -- PURPOSE : Lock and key detection code. -- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Libraries
using UnityEngine.Events;

// Requirements
// NONE

public class LockCore : MonoBehaviour
{

    #region Variables

    [ Tooltip( "Key code SO" ) ]
    [ SerializeField ]
    private KeyCode keyCode;

    [ Tooltip( "Fired when object is unlocked " ) ]
    public UnityEvent onUnlock;

    #endregion

    private void Start()
    { // On init
        
        if ( keyCode == null )
        {

            Debug.Log( "No key code object attatched to the lock: " + this.name );
            Destroy( this.gameObject );

        }

    }

    private void OnTriggerEnter( Collider key )
    { // On trigger enter

        if ( key.CompareTag( "Key" ) )
        { // If object has tag key

            unlock( key.gameObject.GetComponent<KeyCore>().keyCode.code );

        }

    }

    private void unlock( int code )
    { // On key unlock attempt

        if ( code == keyCode.code )
        { // if code matches

            onUnlock.Invoke(); // Unlock event

        }

    }

}
