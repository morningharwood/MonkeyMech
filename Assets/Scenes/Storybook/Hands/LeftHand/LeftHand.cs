using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LeftHand : MonoBehaviour
{
    private Animator animator;
    private float gripTarget;
    private float primaryTarget;
    private float gripCurrent;
    private float primaryCurrent;
    private string animatorLeftHandGripParam = "LeftHandGrip";
    private string animatorLeftHandPrimaryParam = "LeftHandPrimary";

    [SerializeField] private float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //AnimateHand();
    }

    internal void SetGrip(float v)
    {
            
        animator.SetFloat(animatorLeftHandGripParam, v);
        
    }

    internal void SetPrimary(float v)
    {
        primaryTarget = v;
    }

    void AnimateHand()
    {
        if (gripTarget != gripCurrent)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorLeftHandGripParam, gripCurrent);
        }
        if (primaryTarget != primaryCurrent)
        {
            primaryCurrent = Mathf.MoveTowards(primaryCurrent, primaryTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorLeftHandPrimaryParam, primaryCurrent);
        }
    }
}
