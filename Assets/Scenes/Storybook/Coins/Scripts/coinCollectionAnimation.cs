// ---- J A C K - R A N D O L P H ---- \\
// ---- 2 0 2 1 - ALL RIGHTS RESERVED  \\
// -- PURPOSE : When intiated, waits a random time and moves to the players camera while shrinking. -- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Libraries
using UnityEngine.Audio;

// Requirements
// NONE

public class CoinCollectionAnimation : MonoBehaviour
{

    #region Variables

    private bool waitOver;

    [Tooltip("Minimum amount of time the script waits to play collection animation")]
    [SerializeField]
    private float minWaitTime = 2.0f;

    [Tooltip("Maximum amount of time the script waits to play collection animation")]
    [SerializeField]
    private float maxWaitTime = 4.0f;

    [Tooltip("How fast the coin moves")]
    [SerializeField]
    private float speed = 3.0f;

    [Tooltip("Rigidbody")]
    //[SerializeField]
    private Rigidbody rb;

    #endregion

    private void Start()
    { // On init

        rb = gameObject.GetComponent<Rigidbody>();

        StartCoroutine(_coinMoveToPlayer(minWaitTime, maxWaitTime));
        rb.AddForce(Random.Range(-2.0f, 2.0f), Random.Range(0.0f, 2.0f), Random.Range(-2.0f, 2.0f), ForceMode.Impulse);

    }

    private void Update()
    { // On every frame

        if (waitOver)
        {

            this.GetComponent<Rigidbody>().useGravity = false;

            #region Move
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, Time.deltaTime * speed);
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

        if (transform.localScale.x < 0)
        { // Destroys coin once coin has reached scale 0

            //          // TEMP \\
            //GameObject emit = GameObject.Find( "AudioSource" );
            //emit.GetComponent<AudioSource>().PlayOneShot( emit.GetComponent<AudioSource>().clip, 0.5f );
            //          \\ TEMP //

            Destroy(this.gameObject); // Destroys coin

        }

    }

    IEnumerator _coinMoveToPlayer(float minWaitTime, float maxWaitTime)
    { // Wait

        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime)); // Wait

        waitOver = true;

    }

    #region Memory Leak Protection

    private void OnDestroy()
    {

        StopAllCoroutines();

    }

    #endregion

}
