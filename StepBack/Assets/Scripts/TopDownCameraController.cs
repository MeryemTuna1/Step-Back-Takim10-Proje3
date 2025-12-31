using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraController : MonoBehaviour
{
    public Transform target;
    public float height = 15f;
    public float sensitivity = 3f;

    float yaw;

    void Start()
    {
        yaw = transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!CameraManager.Instance.IsTopDown()) return;

        // Mouse X
        yaw += Input.GetAxis("Mouse X") * sensitivity;

        // Pozisyon
        transform.position = target.position + Vector3.up * height;

        // Kuþbakýþý + sað-sol dönüþ
        transform.rotation = Quaternion.Euler(90f, yaw, 0f);
    }

    /*
    public Transform target;
    public float height = 15f;

    void LateUpdate()
    {
        if (!CameraManager.Instance.IsTopDown()) return;

        transform.position = target.position + Vector3.up * height;
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }*/
}
