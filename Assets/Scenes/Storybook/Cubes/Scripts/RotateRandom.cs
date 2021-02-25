using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandom : MonoBehaviour
{
    [SerializeField] private GameObject gameObj;
    [SerializeField] private float speed = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObj.transform.Rotate(0, speed * Time.deltaTime, 0, Space.Self);
    }
}
