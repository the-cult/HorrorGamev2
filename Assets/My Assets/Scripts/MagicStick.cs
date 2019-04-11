using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStick : MonoBehaviour
{

    Animator anim;

    private void Start()
    {

        anim = GameObject.FindGameObjectWithTag("Demon_Lord").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadPoint"))
        {
            anim.SetBool("dying", true);
            Demon_LordController demonController = other.GetComponent<Demon_LordController>();
            demonController.enabled = false;
        }
    }
}
