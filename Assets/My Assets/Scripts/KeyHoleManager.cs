using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHoleManager : MonoBehaviour
{
    public GameObject[] keyHoleSpawnPoints;
    public GameObject keyHole;

    void Awake()
    {
        int keyHoleLoc = Random.Range(0, keyHoleSpawnPoints.Length);
        Instantiate(keyHole, keyHoleSpawnPoints[keyHoleLoc].transform.position, keyHoleSpawnPoints[keyHoleLoc].transform.rotation);
    }


}
