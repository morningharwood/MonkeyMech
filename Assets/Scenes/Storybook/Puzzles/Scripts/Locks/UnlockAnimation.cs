// ---- J A C K - R A N D O L P H ---- \\
// ---- 2 0 2 1 - ALL RIGHTS RESERVED  \\
// -- PURPOSE : Lock animation. Comes apart when unlockAnimation function is fired. -- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Libraries
// NONE

// Requirements
// NONE

public class UnlockAnimation : MonoBehaviour
{

    #region Variables

    [ Tooltip( "Delay before animation plays" ) ]
    [ SerializeField ]
    private float animationDelay = 5.0f;

    [Space(10)]

    [ Tooltip( "Shackle game object" ) ]
    [ SerializeField ]
    private GameObject shackle;

    [ Tooltip( "Lock body game object" ) ]
    [ SerializeField ]
    private GameObject lockBody;

    [Tooltip("Particle effect that plays when unlocked")]
    [SerializeField]
    private GameObject particles;

    private Vector3 lockPartsScale;
    private bool alreadyTriggered;
    private bool shrink;

    #endregion

    public void unlockAnimation()
    { // Unlock animation

        if ( shackle.GetComponent<Rigidbody>() == null )
        { // Create rigidbody on shackle

            Rigidbody rb1 = shackle.AddComponent( typeof( Rigidbody ) ) as Rigidbody;

        }
        if ( lockBody.GetComponent<Rigidbody>() == null )
        { // Create rigidbody on lock body

            Rigidbody rb2 = lockBody.AddComponent( typeof( Rigidbody ) ) as Rigidbody;

        }

        if ( !alreadyTriggered )
        { // Courotine protection

            StartCoroutine( _unlockAnimation( animationDelay ) );

        }

    }

    private void Update()
    { // On every frame

        #region Scaler

        if ( shackle.transform.localScale.x > 0.0f && shrink )
        { // Scale shackle

            shackle.transform.localScale = lockPartsScale;

        }

        if ( lockBody.transform.localScale.x > 0.0f && shrink )
        { // Scale lock body

            lockBody.transform.localScale = lockPartsScale;

        }

        if ( shackle.transform.localScale.x <= 0.0f && lockBody.transform.localScale.x <= 0.0f )
        { // If at scale 0 then destroy

            Destroy( this.gameObject );

        }
        else
        { // If not at scale 0 then continue to shrink

            lockPartsScale = shackle.transform.localScale;
            lockPartsScale.x -= Time.deltaTime;
            lockPartsScale.y -= Time.deltaTime;
            lockPartsScale.z -= Time.deltaTime;

        }

        #endregion

    }

//  // TEMP \\ 
    IEnumerator _unlockAnimation( float animationWait )
    { // Animation controller

        alreadyTriggered = true;
        particles.SetActive(true); // Breaking particles

        yield return new WaitForSeconds( animationWait );

        shrink = true;

    }
//  \\ TEMP // 

    #region Memory Leak Protection

    private void OnDestroy()
    {

        StopAllCoroutines();

    }

    #endregion

}
