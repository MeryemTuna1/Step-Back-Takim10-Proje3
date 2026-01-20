using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ofisNPC : MonoBehaviour
{
    [Header("Waypoints (sýrayla)")]
    public Transform[] points;

    [Header("Settings")]
    public float sitTime = 10f;
    public float walkSpeed = 1.5f;
    public float reachDistance = 0.15f;

    [Header("Animator")]
    public Animator animator;

    void Start()
    {
        StartCoroutine(Routine());
    }

    IEnumerator Routine()
    {
        // 1 OTUR
        animator.SetBool("IsSitting", true);
        animator.SetBool("IsWalking", false);

        yield return new WaitForSeconds(sitTime);

        // 2 KALK
        animator.SetBool("IsSitting", false);
        yield return new WaitForSeconds(0.4f);

        //  YÜRÜ
        animator.SetBool("IsWalking", true);

        for (int i = 0; i < points.Length; i++)
        {
            yield return StartCoroutine(MoveToPoint(points[i]));
        }

        //  SON NOKTA  KAPAT
        animator.SetBool("IsWalking", false);
        gameObject.SetActive(false);
    }

    IEnumerator MoveToPoint(Transform target)
    {
        // YÖNÜ BÝR KERE AYARLA
        Vector3 dir = target.position - transform.position;
        dir.y = 0f;

        if (dir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(dir);

        // HEDEFE YÜRÜ
        while (Vector3.Distance(transform.position, target.position) > reachDistance)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                walkSpeed * Time.deltaTime
            );

            yield return null;
        }
    }

}
