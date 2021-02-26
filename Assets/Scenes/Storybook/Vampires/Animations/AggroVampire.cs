using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AggroVampire : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform target;
    private Animator animator;
    private AIDestinationSetter destinationSetter;
 
    void Start()
    {
        animator = enemy.GetComponent<Animator>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag =="Player")
        {
            destinationSetter.target = target;
            animator.SetBool("isIdol", false);
        }
    }
}
