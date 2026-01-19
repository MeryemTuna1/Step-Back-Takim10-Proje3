using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcMovement : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public Transform walkTarget;

    private bool started = false;

    void Start()
    {
        // BAÞLANGIÇ: oturuyor + yemek yiyor
        agent.enabled = false;

        animator.SetBool("Sit", true);
        animator.SetBool("Eat", true);
        animator.SetBool("Walk", false);
    }

    public void StartSequence()
    {
        if (started) return; // tekrar çalýþmasýn
        started = true;

        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        // Player geldikten sonra 5 sn daha otursun
        yield return new WaitForSeconds(5f);

        // Yemek bitsin, ayaða kalksýn
        animator.SetBool("Eat", false);
        animator.SetBool("Sit", false);
        animator.SetBool("Walk", true);

        agent.enabled = true;
        agent.SetDestination(walkTarget.position);

        // 5 sn yürüsün
        yield return new WaitForSeconds(5f);

        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
