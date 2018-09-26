using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    float verticalMovement;
    float horizontalMovement;

    private void Update()
    {
        // store mouse movement
        verticalMovement = Input.GetAxis("Mouse Y") * speed; //forward
        horizontalMovement = Input.GetAxis("Mouse X") * turnSpeed; //turning
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * verticalMovement * Time.fixedDeltaTime;
        transform.Rotate(new Vector3(0, 0, -horizontalMovement * Time.fixedDeltaTime));
    }
}
