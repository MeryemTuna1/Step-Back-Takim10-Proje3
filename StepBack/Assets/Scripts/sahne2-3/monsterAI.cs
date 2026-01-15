using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monsterAI : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;
    public AudioClip innerVoiceClip2;
    public bool Arrived { get; private set; }

    [Header("Document")]
    public GameObject documentPrefab;
    public Transform documentSpawnPoint;

    void Awake()
    {
        if (anim == null)
            anim = GetComponentInChildren<Animator>();

        if (agent == null)
            agent = GetComponent<NavMeshAgent>();
    }

    public IEnumerator GoToDeskAndDrop(Transform deskPoint)
    {
        Arrived = false;

        agent.isStopped = false;
        agent.SetDestination(deskPoint.position);

        anim.SetBool("WalkC", true);

        // Masaya varana kadar bekle
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            yield return null;
        }

        // Geldi
        agent.isStopped = true;
        anim.SetBool("WalkC", false);

        // Dosya býrak
        anim.SetTrigger("DropDocumentC");
        DropDocument();

        KarakterIcSesManager.Instance.PlayInnerVoice(innerVoiceClip2);

        // Anim bitmesini bekle (drop anim süresi)
        yield return new WaitForSeconds(1.2f);

        // Yok ol
        gameObject.SetActive(false);
    }

    void DropDocument()
    {
        if (documentPrefab == null || documentSpawnPoint == null)
            return;

        GameObject doc = Instantiate(
            documentPrefab,
            documentSpawnPoint.position,
            documentSpawnPoint.rotation
        );

        doc.SetActive(true);

        Rigidbody rb = doc.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true;
    }
}
