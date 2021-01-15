using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flying : MonoBehaviour
{
    [SerializeField] private InputActionReference inputActionLeftPositionRef = null;
    [SerializeField] private InputActionReference inputActionRightPositionRef = null;
    private MechController mechController;
    private Vector3 _sqMag;
    private Vector3 leftPos = new Vector3();
    private Vector3 rightPos = new Vector3();

    private void OnEnable()
    {
        inputActionLeftPositionRef.asset.Enable();
        inputActionRightPositionRef.asset.Enable();
    }

    private void OnDisable()
    {
        inputActionLeftPositionRef.asset.Disable();
        inputActionRightPositionRef.asset.Disable();
    }

    private void Start()
    {
        mechController = GetComponent<MechController>();
        inputActionLeftPositionRef.action.performed += DoChangeLeft;
        inputActionRightPositionRef.action.performed += DoChangeRight;
    }

    private void OnDestroy()
    {
        inputActionLeftPositionRef.action.performed -= DoChangeLeft;
        inputActionRightPositionRef.action.performed -= DoChangeRight;
    }

    void Update()
    {
        Vector3 offset = leftPos - rightPos;
        float sqrMag = offset.sqrMagnitude;
        bool shouldFly = mechController.IsGrounded && offset.sqrMagnitude >= 1.75f;


        print(shouldFly);

    }

    private void DoChangeLeft(InputAction.CallbackContext context)
    {
        leftPos = context.ReadValue<Vector3>();
    }

    private void DoChangeRight(InputAction.CallbackContext context)
    {
        rightPos = context.ReadValue<Vector3>();
    }
}
