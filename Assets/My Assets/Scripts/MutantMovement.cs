using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MutantMovement : MonoBehaviour
{
    public Transform initialPos;
    public GameObject player;
    public float distance;
    //public GameObject gameOver;
    NavMeshAgent nav;
    Animator anim;
    public Animator gameEndAnim;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(player.transform.position, transform.position + Vector3.up, Color.red, 1.0f);
        if ((player.transform.position - transform.position).magnitude < distance)
        {
            if(Physics.Linecast(player.transform.position, transform.position))
            {
                nav.SetDestination(player.transform.position);
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
            gameEndAnim.SetBool("isLost", true);
            Invoke("MainMenu", 5.0f);
            player.GetComponent<OVRPlayerController>().enabled = false;
            //Time.timeScale = 0;
            //gameOver.SetActive(true);
        }
    }

    void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
