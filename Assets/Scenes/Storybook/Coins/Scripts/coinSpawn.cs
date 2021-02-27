// ---- J A C K - R A N D O L P H ---- \\
// ---- 2 0 2 1 - ALL RIGHTS RESERVED  \\
// -- PURPOSE : Spawns coins. (!UP TO THREE FOR NOW!) -- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{

    #region Variables

    [Tooltip( "Coin(s). NOT FINISHED." )]
    [SerializeField]
    private CoinsAsset[] coins;

    [Tooltip( "Max amount of coins that can spawn" )]
    [SerializeField]
    private int maxGibCount = 7;

    private int spawnCurrent; // On current coin spawn...

    #endregion

    private void Start()
    { // On init
       
        if( coins != null )
        { // If coins are in variable "coins"

            StartCoroutine( coinsInstantiate( Random.Range( 3, maxGibCount ) ) );

        }
        else
        { // Destroys object to avoid memory leaks

            Debug.LogWarning( this.transform.name + " has no coins attached." );
            Destroy( this.gameObject );

        }

    }

//  // TEMP \\    
    private void spawnCoin( float chance )
    { // Creates a coin

        if ( chance > 0.6f )
        { // 60% chance

            Instantiate( coins[0].coinMesh, this.transform.position, Quaternion.identity );

        }

        if (chance > 0.3f)
        { // 30% chance

            Instantiate( coins[1].coinMesh, this.transform.position, Quaternion.identity );

        }

        if (chance > 0.1f)
        { // 10% chance

            Instantiate( coins[2].coinMesh, this.transform.position, Quaternion.identity );

        }

    }
//  \\ TEMP //    

    IEnumerator coinsInstantiate( float totalCoins )
    { // Spawn coin(s)

        spawnCurrent = 0;

        while ( spawnCurrent < totalCoins )
        {

            spawnCoin( Random.Range( 0.0f, 1.0f ) );
            spawnCurrent += 1;

        }

        Destroy( this.gameObject );

        yield return null;

    }

    #region Memory Leak Protection
    private void OnDestroy()
    {

        StopAllCoroutines();

    }
    #endregion

}
