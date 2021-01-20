using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Flying : MonoBehaviour
{
    [SerializeField] private InputActionReference inputActionLeftPositionRef = null;
    [SerializeField] private InputActionReference inputActionRightPositionRef = null;
    [SerializeField] private float flySpeed = 10.0f;
    [SerializeField] private float groundedOffset = 0.1f;

    private CharacterController characterController;
    private XRRig rig;

    private Vector3 leftPos = new Vector3();
    private Vector3 rightPos = new Vector3();

    private bool shouldFly = false;

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

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    private void Start()
    {
        
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
        bool tshaped = offset.sqrMagnitude >= 1.75f;
        shouldFly = !IsGrounded && tshaped;
    }

    
    private void FixedUpdate()
    {
        if(shouldFly)
        {
            Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
            Vector3 direction = headYaw * Vector3.forward;
            characterController.Move(direction * Time.fixedDeltaTime * flySpeed);
        }
    }

    private void DoChangeLeft(InputAction.CallbackContext context)
    {
        leftPos = context.ReadValue<Vector3>();
    }

    private void DoChangeRight(InputAction.CallbackContext context)
    {
        rightPos = context.ReadValue<Vector3>();
    }

    public bool IsGrounded => Physics.Raycast(characterController.bounds.center, Vector3.down, characterController.bounds.extents.y + groundedOffset);
}
