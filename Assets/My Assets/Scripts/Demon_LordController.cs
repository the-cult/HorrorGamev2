using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_LordController : MonoBehaviour
{

    public float radius, force;
    float onGroundCounter = 0f;
    float onSkyCounter = 0f;
    public float onGroundTime, onSkyTime;
    Animator anim;
    Rigidbody rb;
    public float flySpeed;
    public Transform flyDest, groundDest;
    bool exploded = false;
    bool gotHurt = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //call Explosion every 4s
        onGroundCounter += Time.deltaTime;
        if (onGroundCounter > 4f && !exploded)
        {
            Explosion();
            exploded = true;
        }
        if (onGroundCounter > 8f)
        {
            exploded = false;
            onGroundCounter = 0f;
            Explosion();
        }
    }



    void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in colliders)
        {
            Rigidbody c_rb = c.GetComponent<Rigidbody>();
            if (c_rb != null)
            {
                c_rb.AddForce(transform.forward * -force, ForceMode.Impulse);
                //gotHurt = true;
                
            }
        }
    }
}
