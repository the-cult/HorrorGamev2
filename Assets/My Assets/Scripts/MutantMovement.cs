using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MutantMovement : MonoBehaviour
{
    public Transform player, initialPos;
    public float distance;
    public GameObject gameOver;
    NavMeshAgent nav;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(player.position, transform.position + Vector3.up, Color.red, 1.0f);
        if ((player.position - transform.position).magnitude < distance)
        {
            if(Physics.Linecast(player.position, transform.position))
            {
                nav.SetDestination(player.position);
                anim.SetBool("isWalking", true);
            }
        }
        else
        {
            nav.SetDestination(initialPos.position);
            if ((transform.position - initialPos.position).magnitude < 0.5f)
            {
                transform.forward = initialPos.forward;
                anim.SetBool("isWalking", false);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
}
