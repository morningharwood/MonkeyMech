// ---- J A C K - R A N D O L P H ---- \\
// ---- 2 0 2 1 - ALL RIGHTS RESERVED  \\
// -- PURPOSE : When intiated, waits a random time and moves to the players camera while shrinking. -- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Libraries
using UnityEngine.Audio;

public class coinMove : MonoBehaviour
{

    #region Variables
    bool waitOver;
    #endregion

    void Start()
    { // On init

        StartCoroutine( _coinMoveToPlayer( 2.0f, 4.0f ) );

    }

    void Update()
    { // On every frame

        if ( waitOver )
        {

            this.GetComponent<Rigidbody>().useGravity = false;

            #region Move
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, Time.deltaTime * 3.0f);
            #endregion

            #region Scale
            Vector3 ScaleCoin;
            ScaleCoin = transform.localScale;
            ScaleCoin.x -= 0.005f;
            ScaleCoin.y -= 0.005f;
            ScaleCoin.z -= 0.005f;
            transform.localScale = ScaleCoin;
            #endregion

        }

        if ( transform.localScale.x < 0 )
        { // Destroys coin once coin has reached scale 0

            GameObject emit = GameObject.Find( "AudioSource" );
            emit.GetComponent<AudioSource>().PlayOneShot( emit.GetComponent<AudioSource>().clip, 1f );
            Destroy( this.gameObject ); // Destroys coin

        }

    }

    IEnumerator _coinMoveToPlayer( float minWaitTime, float maxWaitTime )
    { // Wait

        yield return new WaitForSeconds( Random.Range( minWaitTime, maxWaitTime ) ); // Wait

        waitOver = true;

    }

}
