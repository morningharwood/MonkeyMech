using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Glider : MonoBehaviour
{
    //private ActionBasedController controller;
    //private Vector3 pos;
    //[SerializeField] private string hand;

    //void Start()
    //{
    //    controller = GetComponent<ActionBasedController>();

    //    // Get Position of hands
    //    pos = controller.positionAction.action.ReadValue<Vector3>();

    //    controller.selectAction.action.performed += Action_performed;

    //}

    //private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    //{
    //    Debug.Log(hand + " // " + obj);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Debug.Log(hand + " : " + pos);

    //}

    public bool printStuff = true;
    public InputActionReference testReference = null;

    private void Start()
    {
        testReference.action.started += DoPressedThing;
        testReference.action.performed += DoChangeThing;
        testReference.action.canceled += DoReleasedThing;
    }

    private void OnEnable()
    {
        testReference.asset.Enable();
    }

    private void OnDisable()
    {
        testReference.asset.Disable();
    }

    private void OnDestroy()
    {
        testReference.action.started -= DoPressedThing;
        testReference.action.performed -= DoChangeThing;
        testReference.action.canceled -= DoReleasedThing;
    }

    private void DoPressedThing(InputAction.CallbackContext context)
    {
        if (printStuff)
            print("Pressed");
    }

    private void DoChangeThing(InputAction.CallbackContext context)
    {
        if (printStuff)
            print(context.ReadValue<Vector3>());
    }

    private void DoReleasedThing(InputAction.CallbackContext context)
    {
        if (printStuff)
            print("Released");
    }
}
