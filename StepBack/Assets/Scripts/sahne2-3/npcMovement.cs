using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour
{
    public Transform player;
    public float rotateSpeed = 5f;

    void Update()
    {
        Vector3 dir = player.position - transform.position;
        dir.y = 0;

        Quaternion lookRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            lookRot,
            rotateSpeed * Time.deltaTime
        );
    }
}
