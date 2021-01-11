using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    Animator animator;
    AIDestinationSetter aiSetter;
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        aiSetter = GetComponent<AIDestinationSetter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            aiSetter.target = target.transform;
            animator.SetBool("isWalking", true);
        }
    }
}
