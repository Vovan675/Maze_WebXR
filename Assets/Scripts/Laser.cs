using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class Laser : MonoBehaviour
{
    public WebXRController hand;

    bool isSelected = false;
    XRButton selectedButton;

    LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();    
    }

    void Update()
    {
        if (hand.GetButtonDown(WebXRController.ButtonTypes.ButtonA))
        {
            isSelected = true;
            lr.enabled = true;
        }
        else if (hand.GetButtonUp(WebXRController.ButtonTypes.ButtonA))
        {
            isSelected = false;
            lr.enabled = false;
            if (selectedButton)
            {
                selectedButton.OnClick();
                selectedButton = null;
            }
        }

        if (isSelected)
        {
            UpdateLine();
        }
    }

    void UpdateLine()
    {
        Vector3 endPosition = transform.position + transform.forward * 5.0f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            endPosition = hit.point;
            XRButton button;
            if (hit.collider.gameObject.TryGetComponent<XRButton>(out button))
            {
                selectedButton = button;
                selectedButton.SetSelected(true);
            }
            else
            {
                if (selectedButton)
                {
                    selectedButton.SetSelected(false);
                    selectedButton = null;
                }
            }
        }
        else
        {
            if (selectedButton)
            {
                selectedButton.SetSelected(false);
                selectedButton = null;
            }
        }

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, endPosition);
    }
}
