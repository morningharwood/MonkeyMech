using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechController : MonoBehaviour
{
    private CapsuleCollider _collider;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
    }

    public bool isGrounded
    {
        get
        {
            float extraHeight = .25f;
            bool rayHit = false;
            if (Physics.Raycast(_collider.bounds.center, Vector3.down, _collider.bounds.extents.y + extraHeight))
            {
                rayHit = true;
            }
            else
            {
                rayHit = false;
            }
            return rayHit;
        }
        
    }
}
