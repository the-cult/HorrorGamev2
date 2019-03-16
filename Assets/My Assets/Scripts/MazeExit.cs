using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeExit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOver;

    // Update is called once per frame
   

    private void OnCollisionEnter(Collision collision)
    {
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
