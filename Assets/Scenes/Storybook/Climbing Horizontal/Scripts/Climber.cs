using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    [SerializeField] private InputActionReference inputActionLeftVelocityRef = null;
    [SerializeField] private InputActionReference inputActionRightVelocityRef = null;
    private Vector3 leftVelocity = Vector3.zero;
    private Vector3 rightVelocity = Vector3.zero;
    private CharacterController characterController;
    private ActionBasedContinuousMoveProvider continuousMoveProvider;

    private void OnEnable()
    {
        inputActionLeftVelocityRef.asset.Enable();
        inputActionRightVelocityRef.asset.Enable();
    }

    private void OnDisable()
    {
        inputActionLeftVelocityRef.asset.Disable();
        inputActionRightVelocityRef.asset.Disable();
    }

    private void OnDestroy()
    {
        inputActionLeftVelocityRef.action.performed -= DoChangeLeftVelocity;
        inputActionRightVelocityRef.action.performed -= DoChangeRightVelocity;
    }

    private void Awake()
    {
        continuousMoveProvider = GetComponent<ActionBasedContinuousMoveProvider>();
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        inputActionLeftVelocityRef.action.performed += DoChangeLeftVelocity;
        inputActionRightVelocityRef.action.performed += DoChangeRightVelocity;
    }

    private void FixedUpdate()
    {
        if (ActiveHand.current != null)
        {
            continuousMoveProvider.enabled = false;
            Climb();
        }
        else
        {
            continuousMoveProvider.enabled = true;
        }
    }

    private void Climb()
    {
        if (ActiveHand.current == "Left")
        {
            characterController.Move(transform.rotation * -leftVelocity * Time.fixedDeltaTime);
        }

        if (ActiveHand.current == "Right")
        {
            characterController.Move(transform.rotation * -rightVelocity * Time.fixedDeltaTime);
        }

    }

    private void DoChangeLeftVelocity(InputAction.CallbackContext context)
    {
        leftVelocity = context.ReadValue<Vector3>();
    }

    private void DoChangeRightVelocity(InputAction.CallbackContext context)
    {
        rightVelocity = context.ReadValue<Vector3>();
    }
}
