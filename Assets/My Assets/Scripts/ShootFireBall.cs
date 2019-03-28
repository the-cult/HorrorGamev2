using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootFireBall : MonoBehaviour
{
    OVRGrabbable oVRGrabbable;
    public OVRInput.Button fireButton;
    public int maxNumOfBalls = 6;
    public Text text;
    public GameObject fireBall;
    

    // Start is called before the first frame update
    void Start()
    {
        oVRGrabbable = GetComponent<OVRGrabbable>();
        text.text = maxNumOfBalls.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(oVRGrabbable.isGrabbed && OVRInput.GetDown(fireButton, oVRGrabbable.grabbedBy.GetController()) && maxNumOfBalls > 0)
        {
            maxNumOfBalls--;
            text.text = maxNumOfBalls.ToString();
            Instantiate(fireBall, transform.position + Vector3.forward, transform.rotation);
        }
        if(maxNumOfBalls == 0)
        {
            Destroy(gameObject);
        }
    }
}
