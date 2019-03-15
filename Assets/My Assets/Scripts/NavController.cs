using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavController : MonoBehaviour
{

    NavMeshAgent agent;
    public Transform dest;
    public Transform start;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        agent.destination = dest.position;

        if (agent.destination == dest.position)
        {
            agent.destination = start.position;
        }
    }
}