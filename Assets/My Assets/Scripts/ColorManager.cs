using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public GameObject[] colorRef;
    Renderer rend;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        int colorIndex = Random.Range(0, colorRef.Length); //min inclusive and max exclusive 
        rend.material.color = colorRef[colorIndex].GetComponent<Renderer>().material.color;
    }
}
