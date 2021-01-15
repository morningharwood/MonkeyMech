//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WIP : MonoBehaviour
//{
//    [SerializeField] private InputActionReference inputActionLeftPositionRef = null;
//    [SerializeField] private InputActionReference inputActionRightPositionRef = null;

//    [SerializeField] private GameObject textMeshObj;
//    [SerializeField] private UIInputLoggerScriptableObject uiLogger;
//    private CapsuleCollider _collider;
//    private TextMeshProUGUI textMesh;
//    private MechController mechController;
//    private string message;

//    private Vector3 _sqMag;
//    private void OnEnable()
//    {
//        inputActionLeftPositionRef.asset.Enable();
//        inputActionRightPositionRef.asset.Enable();
//    }
//    private void OnDisable()
//    {
//        inputActionLeftPositionRef.asset.Disable();
//        inputActionRightPositionRef.asset.Disable();
//    }
//    private void Start()
//    {
//        textMesh = textMeshObj.GetComponent<TextMeshProUGUI>();
//        mechController = GetComponent<MechController>();
//        inputActionLeftPositionRef.action.performed += DoChangeLeft;
//        inputActionRightPositionRef.action.performed += DoChangeRight;
//        _collider = GetComponent<CapsuleCollider>();
//    }

//    private void OnDestroy()
//    {
//        inputActionLeftPositionRef.action.performed -= DoChangeLeft;
//        inputActionRightPositionRef.action.performed -= DoChangeRight;
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        string message = "";
//        Vector3 Left = new Vector3();
//        Vector3 Right = new Vector3();


//        Left = StringToVector3(uiLogger.uiValues["Left"]);
//        Right = StringToVector3(uiLogger.uiValues["Right"]);

//        Vector3 offset = Left - Right;
//        float sqrMag = offset.sqrMagnitude;
//        bool shouldFly = false;

//        if (mechController.isGrounded && sqrMag >= 1.75f)
//        {
//            shouldFly = true;
//        }

//        textMesh.text = $"\n" +
//            $"Left: \t\t {Left} \n" +
//            $"Right: \t\t {Right} \n" +
//            $"Offset: \t\t {offset} \n" +
//            $"\n" +
//            $"Left: \t\t {Vec3Abs(Left)} \n" +
//            $"Right: \t\t {Vec3Abs(Right)} \n" +
//            $"Offset Abs: \t\t {Vec3Abs(Left) - Vec3Abs(Right)} \n" +
//            $"\n" +
//            $"SQMag: \t\t {sqrMag} \n" +
//            $"isGrounded: \t\t  {mechController.isGrounded} \n" +
//            $"SHould Fly: \t\t {shouldFly}"
//            ;

//    }


//    private void DoChangeLeft(InputAction.CallbackContext context)
//    {
//        uiLogger.uiValues["Left"] = context.ReadValue<Vector3>().ToString();
//    }

//    private void DoChangeRight(InputAction.CallbackContext context)
//    {
//        uiLogger.uiValues["Right"] = context.ReadValue<Vector3>().ToString();
//    }

//    public static Vector3 StringToVector3(string sVector)
//    {
//        // Remove the parentheses
//        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
//        {
//            sVector = sVector.Substring(1, sVector.Length - 2);
//        }

//        // split the items
//        string[] sArray = sVector.Split(',');

//        // store as a Vector3
//        Vector3 result = new Vector3(
//            float.Parse(sArray[0]),
//            float.Parse(sArray[1]),
//            float.Parse(sArray[2]));

//        return result;
//    }
//    public static Vector3 Vec3Abs(Vector3 v3)
//    {
//        return new Vector3(Mathf.Abs(v3.x), Mathf.Ab
//}
