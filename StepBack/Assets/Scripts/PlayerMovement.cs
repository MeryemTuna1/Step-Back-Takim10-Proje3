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
    private Transform camYaw;

    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        camYaw = CameraManager.Instance.cameraYawRoot;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = camYaw.forward;
        Vector3 right = camYaw.right;

        forward.y = 0;
        right.y = 0;

        Vector3 dir = forward * v + right * h;

        // ANÝMASYON KONTROLÜ
        bool isWalking = dir.magnitude > 0.01f;
        animator.SetBool("isWalk", isWalking);

        if (isWalking)
        {
            controller.Move(dir.normalized * moveSpeed * Time.deltaTime);

            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime
            );
        }

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
