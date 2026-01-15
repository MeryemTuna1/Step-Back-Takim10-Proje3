using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public Transform target;
    public float mouseSensitivity = 3f;
    public float distance = 4f;

    float yaw;


    void Start()
    {
      //  Cursor.lockState = CursorLockMode.Locked;
        yaw = transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!CameraManager.Instance.IsThirdPerson()) return;

        //  SADECE MOUSE X
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        transform.rotation = Quaternion.Euler(0, yaw, 0);
        transform.position = target.position - transform.forward * distance;
    }


    /* public Transform target;
     public float mouseSensitivity = 3f;
     public float distance = 4f;
     public float minY = -30f;
     public float maxY = 60f;

     private float yaw;
     private float pitch;

     void Start()
     {
         Cursor.lockState = CursorLockMode.Locked;
     }

     void LateUpdate()
     {
         if (!CameraManager.Instance.IsThirdPerson()) return;

         yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
         pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
         pitch = Mathf.Clamp(pitch, minY, maxY);

         transform.rotation = Quaternion.Euler(pitch, yaw, 0);
         transform.position = target.position - transform.forward * distance;
     }*/
}
