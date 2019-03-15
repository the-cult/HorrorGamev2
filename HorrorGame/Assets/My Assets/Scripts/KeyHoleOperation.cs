using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHoleOperation : MonoBehaviour
{
    Renderer keyHoleRend;
    public GameObject colorRef;
    public Animator anim;

    void Start()
    {
        keyHoleRend = GetComponent<Renderer>();
        colorRef = GameObject.FindGameObjectWithTag("colorRef");
        anim = GameObject.FindGameObjectWithTag("Door").GetComponent<Animator>();
        keyHoleRend.material.color = colorRef.GetComponent<Renderer>().material.color;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Key")){
            Renderer keyRend = other.gameObject.GetComponent<Renderer>();
            if(keyHoleRend.material.color == keyRend.material.color)
            {
                Debug.Log("Got it!");
                anim.SetBool("isDoorOpened", true);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
