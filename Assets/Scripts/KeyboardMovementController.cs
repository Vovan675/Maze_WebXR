using UnityEngine;
using System.Collections;

public class KeyboardMovementController : MonoBehaviour
{
    public SimpleMove simpleMove;
    Vector2 rotation = Vector2.zero;
    public Transform cam;

    public float RotSpeed = 5.0f;

    void Update()
    {
        Vector2 inputAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        simpleMove.Move(inputAxis);

        rotation.x += Input.GetAxis("Mouse Y") * RotSpeed;
        rotation.x = Mathf.Clamp(rotation.y, -70, 70);

        rotation.y += Input.GetAxis("Mouse X") * RotSpeed;

        //cam.rotation = Quaternion.Euler(-rotation.x, 0, 0);
        transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }
}
