using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClaireMovement : MonoBehaviour
{
    //Vector3 distance;
    public float distance = 2.0f;
    public Transform player;
    public Transform[] waypoints;
    public GameObject[] dialTexts;
    public GameObject Demon_lord, timerText;
    public float talkTime;
    bool followPlayer = false;
    public GameObject instructionText;

   
    Animator anim;
    NavMeshAgent nav;
    int i = 0;
    float talkTimeCounter = 0f;


    AudioSource aud;


    private void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        timerText.SetActive(false);

        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nav.SetDestination(waypoints[i].position);
            anim.SetBool("isWalking", true);
            //Timer.gameTimerStarted = true;
            timerText.SetActive(true);

            aud.Play();
        }

    }

    private void Update()
    {
        /*
        //use this if instead of OnTriggerEnter when using Oculus       
        if (KeyHoleOperation.isClaireFreed)
         {
             nav.SetDestination(waypoints[0].position);
             anim.SetBool("isWalking", true);
             timerText.SetActive(true);
             aud.Play();
         }
         */
        Debug.DrawLine(player.position, transform.position + Vector3.up, Color.red, 1.0f);
        if ((transform.position - waypoints[i].position).magnitude < 1.5f && (transform.position + Vector3.up * 1.2f - player.position).magnitude < 5f)
        {
            transform.forward = player.forward * -1f;
            anim.SetBool("isWalking", false);
            dialTexts[i].SetActive(true);
            talkTimeCounter += Time.deltaTime;
            timerText.SetActive(true);
            aud.Stop();
            if(i == 0)
            {
                Timer.gameTimerStarted = true;
            }
            if (i == waypoints.Length - 1)
            {
                Demon_lord.SetActive(true);
                followPlayer = true;
            }
        }

        if (talkTimeCounter > talkTime && i < waypoints.Length - 1)
        {

            i++;
            nav.SetDestination(waypoints[i].position);
            anim.SetBool("isWalking", true);
            talkTimeCounter = 0f;
            dialTexts[i - 1].SetActive(false);
            aud.Play();
            if (i == waypoints.Length - 1)
            {
                dialTexts[waypoints.Length - 1].SetActive(false);
                instructionText.SetActive(true);
            }
        }


    }

    // Update is called once per frame

    void LateUpdate()
    {
        if (followPlayer)
        {
            FollowPlayer();

        }
    }

    void FollowPlayer()
    {
        Vector3 newPosition;
        newPosition.x = player.position.x;
        newPosition.y = player.position.y - 2f;
        newPosition.z = player.position.z - distance;
        transform.position = newPosition;
        //transform.LookAt(player);
        transform.forward = player.forward * -1f;
        anim.SetBool("isWalking", false);

    }

}

