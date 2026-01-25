using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdCamera : MonoBehaviour
{
    public Transform target;              // ThirdPersonPivot
    public float mouseSensitivity = 3f;
    public float distance = 3f;

    [Header("Wall Collision")]
    public LayerMask wallLayer;
    public float wallPadding = 0.3f;

    float yaw;

    void Start()
    {
        yaw = transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!CameraManager.Instance.IsThirdPerson()) return;

        // Mouse ile sað-sol dön
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.rotation = Quaternion.Euler(0, yaw, 0);

        // Ýdeal pozisyon
        Vector3 desiredPos = target.position - transform.forward * distance;

        // WALL COLLISION
        Vector3 dir = (desiredPos - target.position).normalized;
        float dist = Vector3.Distance(target.position, desiredPos);

        if (Physics.Raycast(target.position, dir, out RaycastHit hit, dist, wallLayer))
        {
            transform.position = hit.point - dir * wallPadding;
        }
        else
        {
            transform.position = desiredPos;
        }
    }
}
