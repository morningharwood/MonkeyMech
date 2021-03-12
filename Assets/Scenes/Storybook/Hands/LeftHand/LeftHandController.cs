using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class LeftHandController : MonoBehaviour
{
    private ActionBasedController controller;
    private LeftHand leftHand;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        leftHand = controller.modelPrefab.GetComponent<LeftHand>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        leftHand.SetGrip(controller.selectAction.action.ReadValue<float>());
        //leftHand.SetPrimary(controller.selectAction.action.ReadValue<float>());
    }
}
