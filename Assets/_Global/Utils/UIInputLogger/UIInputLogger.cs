using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class UIInputLogger : MonoBehaviour
{
    [SerializeField] private GameObject textMeshObj;
    [SerializeField] private UIInputLoggerScriptableObject uiLogger;


    private TextMeshProUGUI textMesh;
    private string message;
    public bool printStuff = true;
    
    public List<InputActionReference> testReference = null;


    private void OnEnable()
    {
        foreach (InputActionReference testRef in testReference)
        {
            testRef.asset.Enable();
        }
    }

    private void OnDisable()
    {
        foreach (InputActionReference testRef in testReference)
        {
            testRef.asset.Disable();
        }
    }


    void Start()
    {
        textMesh = textMeshObj.GetComponent<TextMeshProUGUI>();

        foreach (InputActionReference testRef in testReference)
        {
            
            testRef.action.started += DoPressedThing;
            testRef.action.performed += DoChangeThing;
            testRef.action.canceled += DoReleasedThing;
        }
        
    }
    
    void Update()
    {
        string message = "";
        foreach (KeyValuePair<string, string> kvp in uiLogger.uiValues)
        {
            string[] key = kvp.Key.Split('[');
            message += $"{key[0]} \t {kvp.Value} \n\n";
        }
        textMesh.text = message;
    }
    
    
 
    private void OnDestroy()
    {
        foreach (InputActionReference testRef in testReference)
        {
            testRef.action.started -= DoPressedThing;
            testRef.action.performed -= DoChangeThing;
            testRef.action.canceled -= DoReleasedThing;
        }
       
    }

    private void DoPressedThing(InputAction.CallbackContext context)
    {
        if (printStuff)
            print("Pressed");
    }

    private void DoChangeThing(InputAction.CallbackContext context)
    {
        if (printStuff)
        {
            uiLogger.uiValues[context.action.ToString()] =  context.ReadValue<Vector3>().ToString();
        }

    }

    private void DoReleasedThing(InputAction.CallbackContext context)
    {
        if (printStuff)
            print("Released");
    }



}