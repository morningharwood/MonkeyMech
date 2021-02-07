using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;


public class Climber : MonoBehaviour
{

    private const float MOUNT_TIME = 1.25f;
    private const bool DEBUG_RAY = true;


    private enum ClimbState
    {
        None,
        Climbing,
        AtTop,
        Mounting
    }


    [SerializeField] private InputActionReference inputActionLeftVelocityRef = null;
    [SerializeField] private InputActionReference inputActionRightVelocityRef = null;
    private Vector3 leftVelocity = Vector3.zero;
    private Vector3 rightVelocity = Vector3.zero;
    private CharacterController characterController;
    private ActionBasedContinuousMoveProvider continuousMoveProvider;
    private BodyOrientation bodyOrientation;
    private ClimbState _state = ClimbState.None;
    private Vector3 _mountDestinationPosition;
    private float _mountTimeElapsed; 


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
        bodyOrientation = GetComponent<BodyOrientation>();
    }

    void Start()
    {
        inputActionLeftVelocityRef.action.performed += DoChangeLeftVelocity;
        inputActionRightVelocityRef.action.performed += DoChangeRightVelocity;
    }

    private void FixedUpdate()
    {
        if (_state == ClimbState.Mounting)
        {
            ContinueToMount();
        }
        else if (ActiveHand.current != null)
        {
            continuousMoveProvider.enabled = false;
            Climb();
            UpateClimbState();
        }
        else
        {
            FinishedClimbing();
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


    private void UpateClimbState()
    {
        const float NECK_DOWN_FROM_CAMERA = -0.25f;
        const float MAX_HIT_DISTANCE = 2.0f;

        Vector3 rayForwardFromNeck = 
            bodyOrientation.CameraPosition +
            (bodyOrientation.UpDirection * NECK_DOWN_FROM_CAMERA);

        // for debugging purposes
        transform.GetComponent<LineRenderer>().enabled = DEBUG_RAY;
        transform.GetComponent<LineRenderer>().SetPosition(0, rayForwardFromNeck);
        Vector3 targetPosition = rayForwardFromNeck + bodyOrientation.ForwardFacingDirection * MAX_HIT_DISTANCE;
        transform.GetComponent<LineRenderer>().SetPosition(1, targetPosition);

        _state = ClimbState.Climbing;

        if (ActiveHand.current != null)
        {
            bool atTop = true;

            RaycastHit[] hits = Physics.RaycastAll(rayForwardFromNeck, bodyOrientation.ForwardFacingDirection, MAX_HIT_DISTANCE); 
            if (hits != null && hits.Length > 0)
            {
                var otherHits = hits.Where(hit => hit.transform.gameObject != this.transform.gameObject);

                if (otherHits.Count() > 0)
                {
                    atTop = false;
                    transform.GetComponent<LineRenderer>().SetPosition(1, otherHits.OrderByDescending(hit => hit.distance).First().point);
                }
            }

            if (atTop)
            {
                _state = ClimbState.AtTop;
            }
        }
    }


    private void FinishedClimbing()
    {
        const float MOUNT_DISTANCE_FORWARD = 1.5f;
        const float MOUNT_DISTANCE_UP = 1.0f;

        if (_state == ClimbState.None) return;

        continuousMoveProvider.enabled = true;

        if (_state == ClimbState.AtTop)
        {
            // player needs to move forward and up in order to arrive on top of climbable.
            _mountDestinationPosition = 
                transform.position + 
                (bodyOrientation.ForwardFacingDirection * MOUNT_DISTANCE_FORWARD) +
                (bodyOrientation.UpDirection * MOUNT_DISTANCE_UP);

            _mountTimeElapsed = 0;
            _state = ClimbState.Mounting;
        }
        else
        {
            _state = ClimbState.None;
            transform.GetComponent<LineRenderer>().enabled = false;
        }
    }


    private void ContinueToMount()
    {
        _mountTimeElapsed += Time.fixedDeltaTime;

        transform.position = Vector3.Lerp(transform.position, _mountDestinationPosition, _mountTimeElapsed / MOUNT_TIME);

        if (_mountTimeElapsed > MOUNT_TIME)
        {
            _state = ClimbState.None;
            transform.GetComponent<LineRenderer>().enabled = false;
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
