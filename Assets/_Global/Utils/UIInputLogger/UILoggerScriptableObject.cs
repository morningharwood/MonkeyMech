using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UILoggerType
{
    UIInput
}

public abstract class UILoggerScriptableObject : ScriptableObject
{
    protected UILoggerType type;
}
