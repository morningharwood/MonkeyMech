using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class ForceCube : MonoBehaviour
{
    [SerializeField] private InputActionReference inputActionLeftPositionRef = null;
    [SerializeField] private InputActionReference inputActionRightPositionRef = null;
    [SerializeField] private InputActionReference inputActionLeftActivateRef = null;
    [SerializeField] private InputActionReference inputActionRightActivateRef = null;
    [SerializeField] private Transform LeftHand;
    [SerializeField] private Transform RightHand;
    [SerializeField] private float maxHandDistance = 1.75f;
    [SerializeField] private Vector3 minScale = Vector3.zero;
    [SerializeField] private Vector3 maxScale = new Vector3(0.25f, 0.25f, 0.25f);
    [SerializeField] private float startingDistance = 0.25f;
    [SerializeField] private GameObject cube;
    
    // Input
    private Vector3 leftPos = Vector3.zero;
    private Vector3 rightPos = Vector3.zero;
    private bool leftActivateButtonPressed = false;
    private bool rightActivateButtonPressed = false;
    private GameObject _cube;


    // State
    //private bool isScaling = false;
    //private bool endScaling = false;
    private bool isCubePresent = false;


    private void OnEnable()
    {
        inputActionLeftPositionRef.asset.Enable();
        inputActionLeftActivateRef.asset.Enable();

        inputActionRightPositionRef.asset.Enable();
        inputActionRightActivateRef.asset.Enable();
    }

    private void OnDisable()
    {
        inputActionLeftPositionRef.asset.Disable();
        inputActionLeftActivateRef.asset.Disable();

        inputActionRightPositionRef.asset.Disable();
        inputActionRightActivateRef.asset.Disable();
    }

    private void OnDestroy()
    {
        inputActionLeftPositionRef.action.performed -= DoChangeLeftPosition;
        inputActionRightPositionRef.action.performed -= DoChangeRightPosition;
        inputActionLeftActivateRef.action.performed -= DoChangeLeftActivate;
        inputActionRightActivateRef.action.performed -= DoChangeRightActivate;
    }


    private void Start()
    {

        inputActionLeftPositionRef.action.performed += DoChangeLeftPosition;
        inputActionRightPositionRef.action.performed += DoChangeRightPosition;
        inputActionLeftActivateRef.action.performed += DoChangeLeftActivate;
        inputActionRightActivateRef.action.performed += DoChangeRightActivate;
    }

    private void Update()
    {
        Vector3 offset = leftPos - rightPos;
        bool handsAreCloseTogether = offset.sqrMagnitude <= startingDistance;
        
        bool start = !isCubePresent && handsAreCloseTogether && leftActivateButtonPressed && rightActivateButtonPressed;
        bool moving = isCubePresent && leftActivateButtonPressed && rightActivateButtonPressed;
        bool end = isCubePresent && !leftActivateButtonPressed && !rightActivateButtonPressed;

        if (start)
        {
            isCubePresent = true;
            Vector3 center = Vector3.Lerp(LeftHand.position, RightHand.position, 0.5f);
            _cube = Instantiate(cube, center, Quaternion.identity);
        }
        else if (moving)
        {
            float normalizedHandDistance = offset.sqrMagnitude * maxHandDistance;
            Vector3 localScale = Vector3.Lerp(minScale, maxScale, normalizedHandDistance); ;
            _cube.transform.localScale = localScale;
        }
        else if(end)
        {
            print("ENDDD");
            isCubePresent = false;
        }
    }


    private void DoChangeLeftPosition(InputAction.CallbackContext context)
    {
        leftPos = context.ReadValue<Vector3>();
    }

    private void DoChangeRightPosition(InputAction.CallbackContext context)
    {
        rightPos = context.ReadValue<Vector3>();
    }

    private void DoChangeLeftActivate(InputAction.CallbackContext context)
    {
        float val = context.ReadValue<float>();
        leftActivateButtonPressed = val > 0.9f;
        print("LEFT" + val);
    }

    private void DoChangeRightActivate(InputAction.CallbackContext context)
    {
        float val = context.ReadValue<float>();
        rightActivateButtonPressed = val > 0.9f;
        print("RIGHT" + val);
    }
}
