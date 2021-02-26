// ---- J A C K - R A N D O L P H ---- \\
// ---- 2 0 2 1 - ALL RIGHTS RESERVED  \\
// -- PURPOSE : Spawns coins. (!UP TO THREE FOR NOW!) -- \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawn : MonoBehaviour
{

    #region Variables

    public coinsAsset[] coins;
    public int maxGibCount = 35;

    #endregion

    void Start()
    { // On init
       
        if( coins != null )
        { // If coins are in variable "coins"

            StartCoroutine( coinsInstantiate() );

        }
        else
        { // Destroys object to avoid crashes

            Debug.LogWarning( this.transform.name + " has no coins attached." );
            Destroy( this.gameObject );

        }

    }

    void spawnCoin()
    { // Creates a coin

        float chance = Random.value;

        if ( chance > 0.6f )
        { // 60% chance

            Instantiate( coins[0].coinMesh, new Vector3( this.transform.position.x, this.transform.position.y, this.transform.position.z ), Quaternion.identity );

        }

        if (chance > 0.3f)
        { // 30% chance

            Instantiate( coins[1].coinMesh, new Vector3( this.transform.position.x, this.transform.position.y, this.transform.position.z ), Quaternion.identity );

        }

        if (chance > 0.1f)
        { // 10% chance

            Instantiate( coins[2].coinMesh, new Vector3( this.transform.position.x, this.transform.position.y, this.transform.position.z ), Quaternion.identity );

        }

    }

    IEnumerator coinsInstantiate()
    { // Spawn coin(s)

        int spawnCurrent = 0;
        int coinsSpawnAmount = Random.Range( 3, maxGibCount );

        while ( spawnCurrent < coinsSpawnAmount )
        {

            spawnCoin();
            spawnCurrent += 1;

        }

        Destroy( this.gameObject );

        yield return null;

    }

}
