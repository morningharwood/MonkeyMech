using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Logger Object", menuName = "Logger/UI Input")]
public class UIInputLoggerScriptableObject : UILoggerScriptableObject
{
    public Dictionary<string, string> uiValues = new Dictionary<string, string>();

    public void Awake()
    {
        type = UILoggerType.UIInput;
    }
}
