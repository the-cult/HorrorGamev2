using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPointManager : MonoBehaviour
{

    public Transform nextTeleportPoint;
    public GameObject teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(teleportPoint, nextTeleportPoint.position, nextTeleportPoint.rotation);
            //Demon_LordController.playerArrived = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Demon_LordController.playerArrived = false;

        }
    }
}
