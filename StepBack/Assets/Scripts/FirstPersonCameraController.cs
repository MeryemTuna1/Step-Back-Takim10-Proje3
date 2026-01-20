using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float sensitivity = 3f;

    float yaw;

    // SHAKE deðiþkenleri
    float shakeDuration = 0f;
    float shakeMagnitude = 0f;

    void Start()
    {
        yaw = target.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!CameraManager.Instance.IsFirstPerson()) return;

        //  Mouse X
        yaw += Input.GetAxis("Mouse X") * sensitivity;

        // Kamera pozisyonu
        transform.position = target.position + offset;

        // Kamera sað-sol döner
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        // Player da ayný yöne baksýn
        target.rotation = Quaternion.Euler(0f, yaw, 0f);
    }

    public void StartShake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
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
