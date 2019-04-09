using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClairFollow : MonoBehaviour
{
    //Vector3 distance;
    //float distance = 1.0f;
    public Transform player;
    public Transform[] waypoints;
    public GameObject Demon_lord, timerCanvas;
    bool gotPlayer = false;
    Animator anim;
    NavMeshAgent nav;
    int i = 0;
    public GameObject teleportPoint;
    public Transform teleSpawnPoint;
    bool isSneaking = false;
    public Transform waypoint;


    private void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        timerCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timerCanvas.SetActive(true);
            nav.SetDestination(waypoints[i].position);
            //nav.SetDestination(waypoint.position);
            anim.SetBool("isWalking", true);
            if (i < 3)
            {
                i++;
            }
            if (i == 2)
            {
                Demon_lord.SetActive(true);
                Instantiate(teleportPoint, teleSpawnPoint.position, teleSpawnPoint.rotation);
            }
        }

    }

    private void Update()
    {
        //nav.SetDestination(waypoint.position);
        if ((transform.position - waypoints[i].position).magnitude < 1f)
        {
            transform.LookAt(player);
            anim.SetBool("isWalking", false);
            /*

            if (3 < i && i < 6 && !isSneaking)
            {
                isSneaking = true;
                Invoke("Sneaking", 3f);
                Demon_LordController.ClaireArrived = true;
            }
            */
        }
    }

    void Sneaking ()
    {
        i++;
        isSneaking = false;
        Demon_LordController.ClaireArrived = false;
    }
    // Update is called once per frame
    /*
    void LateUpdate()
    {
        if (gotPlayer)
        {
            Vector3 newPosition;
            newPosition.x = player.position.x;
            newPosition.y = player.position.y;
            newPosition.z = player.position.z - distance;
            transform.position = newPosition;
            transform.LookAt(player);
            anim.SetBool("isWalking", true); 

        }
    }
    */
}
