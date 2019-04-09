using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavController : MonoBehaviour
{

    NavMeshAgent agent;
   //public Transform dest;
    //public Transform start;
    public float radius, force;
    
   //public GameObject gameover;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }
    /*
    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in colliders)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
    }
    */
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Throwable"))
        {
            Invoke("Explosion", 1.0f);
        }
        //Time.timeScale = 0;
        //gameover.SetActive(true);
        //Debug.Log("hit");
    }

    void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in colliders)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * -force, ForceMode.Impulse);
            }
        }
    }
    /*
    private void Update()
    {
        agent.destination = dest.position;

        if (agent.destination == dest.position)
        {
            agent.destination = start.position;
        }
    }
    */
}