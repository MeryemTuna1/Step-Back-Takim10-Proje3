using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 1.6f, 0f);
    public float sensitivity = 3f;

    float yaw;

    void Start()
    {
        yaw = target.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!CameraManager.Instance.IsFirstPerson()) return;

        yaw += Input.GetAxis("Mouse X") * sensitivity;

        // OFFSET'I TARGET'IN LOCAL SPACE'ÝNDE UYGULA
        transform.position = target.TransformPoint(offset);

        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
        target.rotation = Quaternion.Euler(0f, yaw, 0f);
    }

    /*public Transform target;
    public Vector3 offset = new Vector3(0, 1.6f, 0);

    void LateUpdate()
    {
        if (!CameraManager.Instance.IsFirstPerson()) return;

        transform.position = target.position + offset;
        transform.rotation = target.rotation;
    }*/
}
