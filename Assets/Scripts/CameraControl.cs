using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public float cameraSensitivity = 120;
    public float verticalLookLimit = 75;

    public float normalMovementSpeed = 10;
    public float climbSpeed = 4;
    public float slowMoveFactor = 0.25f;

    float rotationX = 0.0f;
    float rotationY = 0.0f;

    void Start()
    {
        rotationX = transform.rotation.x;
        rotationY = transform.rotation.y;
    }

    void Update()
    {
        if (Input.GetButton("Fly"))
        {
            rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -verticalLookLimit, verticalLookLimit);

            transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

            if (Input.GetButton("Slow"))
            {
                transform.position += transform.forward * (normalMovementSpeed * slowMoveFactor) * Input.GetAxis("Front") * Time.deltaTime;
                transform.position += transform.right * (normalMovementSpeed * slowMoveFactor) * Input.GetAxis("Strafe") * Time.deltaTime;
                transform.position += transform.up * (climbSpeed * slowMoveFactor) * Input.GetAxis("Up") * Time.deltaTime;
            }
            else
            {
                transform.position += transform.forward * normalMovementSpeed * Input.GetAxis("Front") * Time.deltaTime;
                transform.position += transform.right * normalMovementSpeed * Input.GetAxis("Strafe") * Time.deltaTime;
                transform.position += transform.up * climbSpeed * Input.GetAxis("Up") * Time.deltaTime;
            }
        }

        if (Input.GetButtonDown("Fly"))
            Cursor.visible = false;
        else if (Input.GetButtonUp("Fly"))
            Cursor.visible = true;
    }
}