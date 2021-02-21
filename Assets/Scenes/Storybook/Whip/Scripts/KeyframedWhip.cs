using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyframedWhip : MonoBehaviour
{
    [SerializeField] private InputActionReference inputActionRightTriggerRef = null;
    [SerializeField] private InputActionReference inputActionRightPositionRef = null;
    [SerializeField] private float inputThreshold = 0.1f;
    [SerializeField] private float newPositionThresholdDistance = 0.05f;
    [SerializeField] private float whipSpeed = 1f;
    [SerializeField] private GameObject whipSegmentPrefab = null;

    private XRRig rig = null;
    private bool isPressed = false;
    private bool isAnimating = false;
    private bool isMoving = false;
    private Vector3 target = Vector3.zero;
    private Vector3 rightHandPosition = Vector3.zero;
    
    private List<Vector3> positionList = new List<Vector3>();
    private List<GameObject> whipSegementsAnimation = new List<GameObject>();
    
    

    private void OnEnable()
    {
        inputActionRightTriggerRef.asset.Enable();
        inputActionRightPositionRef.asset.Enable();
    }

    private void OnDisable()
    {
        inputActionRightTriggerRef.asset.Disable();
        inputActionRightPositionRef.asset.Disable();
    }

    private void Awake()
    {
        rig = GetComponent<XRRig>();
    }


    // Start is called before the first frame update
    void Start()
    {
        inputActionRightTriggerRef.action.performed += DoChangeRightTrigger;
        inputActionRightPositionRef.action.performed += DoChangeRightPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMoving && isPressed)
        {
            StartMovement();
        }   
        // 
        else if(isMoving && !isPressed)
        {
            EndMovement();
        }
        // Updating the movement
        else if(isMoving && isPressed)
        {
            UpdateMovement();
        }
    }

    private void FixedUpdate()
    { 
        if(isAnimating)
        {
            foreach (GameObject segment in whipSegementsAnimation)
            {
                segment.transform.position += Vector3.forward * Time.fixedDeltaTime * whipSpeed;
                float distance = (new Vector3(0, 0, 4) - segment.transform.position).sqrMagnitude;
                print(distance);
                if (distance <= 10f)
                {
                    DestroyWhipSegments();
                    isAnimating = false;
                }
            }
        }
        
    }

    private void DestroyWhipSegments()
    {
        foreach (GameObject segment in whipSegementsAnimation)
        {
            Destroy(segment);
        }
        whipSegementsAnimation.Clear();
    }

    private void DoChangeRightTrigger(InputAction.CallbackContext context)
    {
        print(context.ReadValue<float>());
        isPressed = context.ReadValue<float>() >= 1.0f;
    }

    private void DoChangeRightPosition(InputAction.CallbackContext context)
    {
        rightHandPosition = context.ReadValue<Vector3>();
    }

    private void StartMovement()
    {
        isMoving = true;
        positionList.Clear();
        positionList.Add(rightHandPosition);
        if(whipSegmentPrefab)
        {
            whipSegementsAnimation.Add(Instantiate(whipSegmentPrefab, rightHandPosition, Quaternion.identity));
        }
        
    }
    private void EndMovement()
    {
        if(positionList.Count > 4)
        {
            isAnimating = true;
        }
        
        isMoving = false;
    }

    private void UpdateMovement()
    {
        Vector3 lastPosition = positionList[positionList.Count - 1];
        if(Vector3.Distance(rightHandPosition, lastPosition) > newPositionThresholdDistance)
        {
            positionList.Add(rightHandPosition);
            if (whipSegmentPrefab)
            {
                whipSegementsAnimation.Add(Instantiate(whipSegmentPrefab, rightHandPosition, Quaternion.identity));
            }
        }
        

    }

}
