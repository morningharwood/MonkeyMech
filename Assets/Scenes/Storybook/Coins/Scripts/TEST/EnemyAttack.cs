// ---- J A C K - R A N D O L P H ---- \\
// ---- 2 0 2 1 - ALL RIGHTS RESERVED  \\
// -- PURPOSE : Allows player to attack an enemy. -- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{ // NOT COMPLETED.

    #region Variables

    [Tooltip("Coin spawner(s)")]
    [SerializeField]
    private CoinSpawn[] coinSpawners;

    [Tooltip("Vampire Health")]
    [SerializeField]
    private int health = 1;

    #endregion

    private void Awake()
    { // On awake

        foreach ( CoinSpawn coinSpawner in coinSpawners )
        {

            coinSpawner.gameObject.SetActive( false );

        }

    }

    private void OnCollisionEnter( Collision weapon )
    { // On impact of the weapon

        if ( weapon.gameObject.CompareTag("Wacker") && weapon.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 3f )
        {
            
            foreach ( CoinSpawn coinSpawner in coinSpawners )
            {

                coinSpawner.gameObject.SetActive( true );

            }

            Destroy( this.gameObject );

        }

    }

}
