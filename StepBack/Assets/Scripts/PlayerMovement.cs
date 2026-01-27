using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float rotationSpeed = 12f;

    private CharacterController controller;
    private Vector3 velocity;

    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (CameraManager.Instance == null) return;

        Camera activeCam = CameraManager.Instance.GetActiveCamera();
        if (activeCam == null) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // AKTÝF KAMERAYA GÖRE YÖN
        Vector3 forward = activeCam.transform.forward;
        Vector3 right = activeCam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 dir = forward * v + right * h;

        // ANÝMASYON
        bool isWalking = dir.magnitude > 0.01f;
        animator.SetBool("isWalk", isWalking);

        if (isWalking)
        {
            controller.Move(dir.normalized * moveSpeed * Time.deltaTime);

            // SADECE 3rd Person'da karakter yönünü hareket yönüne çevir
            if (!CameraManager.Instance.IsFirstPerson())
            {
                Quaternion targetRot = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRot,
                    rotationSpeed * Time.deltaTime
                );
            }
        }

        // GRAVITY
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
