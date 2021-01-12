using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Glider : MonoBehaviour
{
    private ActionBasedController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();

        // Get Position of hands
        Vector3 pos = controller.positionAction.action.ReadValue<Vector3>();
        Debug.Log(pos);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
