using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monsterAI : MonoBehaviour
{
    NavMeshAgent agent;

    public bool Arrived { get; private set; }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void GoToDesk(Transform deskPoint)
    {
        Arrived = false;
        agent.SetDestination(deskPoint.position);
    }

    void Update()
    {
        if (!agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance)
        {
            Arrived = true;
            
        }

    }

}
