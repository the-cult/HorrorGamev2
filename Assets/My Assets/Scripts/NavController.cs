using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavController : MonoBehaviour
{

    NavMeshAgent agent;
    public Transform dest;
    public Transform start;
    public GameObject gameover;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0;
        gameover.SetActive(true);
        Debug.Log("hit");
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