using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeExit : MonoBehaviour
{

    //public GameObject GameOver;
    public Animator anim;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isWon", true);
            player.GetComponent<OVRPlayerController>().enabled = false;
            Invoke("MainMenu", 5.0f);
        }
        //GameOver.SetActive(true);
        //Time.timeScale = 0;
    }

    void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
