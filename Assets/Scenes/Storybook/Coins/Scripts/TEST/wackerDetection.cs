using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wackerDetection : MonoBehaviour
{

    public GameObject coinsSpawner;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Wacker") && collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 3f)
        {

            Instantiate(coinsSpawner, transform.position, transform.rotation);
            Destroy(this.gameObject);

        }

    }

}
