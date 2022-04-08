using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public CharacterController characterController;
    public bool Movable = true;


    public void Move(Vector2 input)
    {
        if (Movable)
        {
            if (input.magnitude < 0.1f) return;

            input.Normalize();

            float angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);

            Vector3 movement = rot * transform.forward * 3.0f;
            characterController.SimpleMove(movement);
        }
    }
}
