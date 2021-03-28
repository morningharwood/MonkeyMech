using UnityEngine;
using static Whipper;
using System;


public class Whippable : MonoBehaviour
{


    public delegate void WhippedEvent(Whippable sender, WhippedInformation info);
    public delegate void AttachedToWhipEvent(Whippable sender);
    public delegate void DetachedFromWhipEvent(Whippable sender);


    public WhippedEvent OnWhipped = null;
    public AttachedToWhipEvent OnAttachedToWhip = null;
    public DetachedFromWhipEvent OnDetachedFromWhip = null;
    

    private const int DEBOUNCE_MILLISECONDS = 250;


    public bool Attachable = false;
    public int WhippedCount = 0;

    private bool _isAttached = false;
    private DateTime _debounce = DateTime.MinValue;


    public void InvokeWhipped(WhippedInformation info)
    {
        if (_debounce > DateTime.Now) 
        {
            ExtendDebounce();
            return;
        }

        WhippedCount++;
        UnityEngine.Debug.Log("Whippable: whipped");
        OnWhipped?.Invoke(this, info);

        ExtendDebounce();
    }
    

    public void InvokeAttachedToWhip()
    {
        _isAttached = true;
        UnityEngine.Debug.Log("Whippable: attached");
        OnAttachedToWhip?.Invoke(this);
    }
    

    public void InvokeDetachedFromWhip()
    {
        _isAttached = false;
        UnityEngine.Debug.Log("Whippable: detached");
        OnDetachedFromWhip?.Invoke(this);
    }


    private void ExtendDebounce()
    {
        _debounce = DateTime.Now.AddMilliseconds(DEBOUNCE_MILLISECONDS);
    }


    public bool IsAttached
    {
        get
        {
            return _isAttached;
        }
    }


}
