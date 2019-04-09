using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_LordController : MonoBehaviour
{
    public static bool playerArrived = false;
    public static bool ClaireArrived = false;
    bool targetDetected = false;
    public float radius, force;
    float counter = 0f;

    private void FixedUpdate()
    {
        //check if the player and Claire arrived at their corresponding destinations at the same time
        if (playerArrived != ClaireArrived && !targetDetected)
        {
            counter += Time.fixedDeltaTime;
            if (counter >= 0.5f)
            {
                targetDetected = true;
                Invoke("Explosion", 1.0f);
                counter = 0f;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Throwable"))
        {
            Invoke("Explosion", 1.0f);
        }
    }

    void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in colliders)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * -force, ForceMode.Impulse);
            }
        }
    }
}
