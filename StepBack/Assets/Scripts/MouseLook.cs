using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 3f;

    float yaw;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yaw = transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        //  SADECE SAÐ - SOL
        yaw += Input.GetAxis("Mouse X") * sensitivity;

        // Camera Root / Pivot sað-sol döner
        transform.rotation = Quaternion.Euler(0, yaw, 0);

        // Aktif kamerayý al (3rd / 1st / TopDown)
        Camera cam = CameraManager.Instance.GetActiveCamera();

        //  Mouse Y tamamen kapalý  sabit bakýþ
        cam.transform.localRotation = Quaternion.identity;
    }
}
