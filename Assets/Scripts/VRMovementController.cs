using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class VRMovementController : MonoBehaviour
{
    public WebXRController hand;
    public SimpleMove simpleMove;

    void Update()
    {
        Vector2 axisInput = hand.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick);
        if (axisInput == Vector2.zero)
        {
            axisInput = hand.GetAxis2D(WebXRController.Axis2DTypes.Touchpad);
        }

        if (hand.GetButton(WebXRController.ButtonTypes.Thumbstick) || hand.GetButton(WebXRController.ButtonTypes.Touchpad))
        {
            simpleMove.Move(axisInput);
        }
    }
}
