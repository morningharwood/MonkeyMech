using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class BodyOrientation : MonoBehaviour
{

    /*
        Had difficulty finding the orientation of the character's body
        easy to get orientation of camera, but doesn't work if the user moves head (looks away from body facing direction)
        further orientation problems occur when using snap turn

        Solution:
            Assume hands are in front of body, doing something (climbing etc.)
            Find center point between hands
            Forward direction is from camera in the direction of that center point

        
        NOTE:
            If we use this often, we should move the UpdateOrientation call to FixedUpdate (once per frame)
    */


    public struct BodyOrientationInformation
    {
        public Vector3 CameraPosition;
        public Vector3 UpDirection;
        public Vector3 ForwardFacingDirection;
    }


    private GameObject _camera;
    private GameObject _character;
    private UnityEngine.XR.InputDevice _leftHandDevice;
    private UnityEngine.XR.InputDevice _rightHandDevice;
    private BodyOrientationInformation _lastOrientation;


    private void Awake()
    {
        CharacterController characterController = GetComponent<CharacterController>();
        _character = characterController.transform.gameObject;

        _camera = GetComponent<XRRig>().cameraGameObject;

        _leftHandDevice = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.LeftHand);
        _rightHandDevice = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand);

        _lastOrientation = new BodyOrientationInformation();
    }


    private void UpdateOrientation()
    {
        Vector3 leftHandPosition, rightHandPosition;
        _leftHandDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out leftHandPosition);
        _rightHandDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out rightHandPosition);

        // we need our center point in world position
        leftHandPosition = _character.transform.TransformPoint(leftHandPosition);
        rightHandPosition = _character.transform.TransformPoint(rightHandPosition);

        Vector3 centerPoint = new Vector3(
            ((leftHandPosition.x + rightHandPosition.x) / 2), 
            ((leftHandPosition.y + rightHandPosition.y) / 2),
            ((leftHandPosition.z + rightHandPosition.z) / 2)
        );

        // get a horizontal vector from our camera in assumed body direction
        Vector3 cameraPosition = _camera.transform.position;
        Vector3 forwardFacingDirection = centerPoint - cameraPosition;
        _lastOrientation.ForwardFacingDirection = new Vector3(forwardFacingDirection.x, 0, forwardFacingDirection.z);

        _lastOrientation.UpDirection = _character.transform.up;

        //TODO: why did we change y component here?
        // we'll be "above" the top of the wall when our neck clear's the climbable
        _lastOrientation.CameraPosition = new Vector3(cameraPosition.x, _camera.transform.position.y, cameraPosition.z);
    }


    public BodyOrientationInformation GetOrientation()
    {
        UpdateOrientation();
        return _lastOrientation;
    }


}