using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class esMovement : MonoBehaviour
{
    [Header("References")]
    public Animator animator;
    public AudioSource audioSource;

    [Header("Movement")]
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public float rotateSpeed = 5f;

    [Header("Audio")]
    public AudioClip waveSound;

    public plateCarry isOkey;

    private bool hasStarted = false;

    private void Start()
    {
        animator.applyRootMotion = false;
    }

    void Update()
    {
        // SADECE 1 KEZ BAÞLASIN
        if (isOkey.isOk && !hasStarted)
        {
            hasStarted = true;
            StartCoroutine(Routine());
        }
    }

    IEnumerator Routine()
    {
        // BAÞLANGIÇ OTUR
        animator.SetBool("IsSitting", true);
        animator.SetBool("IsWalking", false);

        yield return new WaitForSeconds(1f);

        // KALK YÜRÜ
        animator.SetBool("IsSitting", false);
        animator.SetBool("IsWalking", true);

        // WAYPOINTLERÝ GEZ
        for (int i = 0; i < waypoints.Length; i++)
        {
            yield return MoveToPoint(waypoints[i]);
        }

        // SON POINTTE DUR
        animator.SetBool("IsWalking", false);

        // EL SALLA
        animator.SetTrigger("Wave");

        if (waveSound != null && audioSource != null)
            audioSource.PlayOneShot(waveSound);
    }

    IEnumerator MoveToPoint(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            // YÖNE DÖN
            Vector3 dir = (target.position - transform.position).normalized;
            Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                lookRot,
                rotateSpeed * Time.deltaTime
            );

            // ÝLERLE
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }
    }
}
