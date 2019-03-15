using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject[] keys, spawnPoints;
    int firstKeyLoc, secondKeyLoc, thirdKeyLoc;

    void Start()
    {
        firstKeyLoc = Random.Range(0, spawnPoints.Length);
        do
        {
            secondKeyLoc = Random.Range(0, spawnPoints.Length);
        } while (secondKeyLoc == firstKeyLoc);

        do
        {
            thirdKeyLoc = Random.Range(0, spawnPoints.Length);
        } while (thirdKeyLoc == firstKeyLoc || thirdKeyLoc == secondKeyLoc);


        Instantiate(keys[0], spawnPoints[firstKeyLoc].transform.position, spawnPoints[firstKeyLoc].transform.rotation);
        Instantiate(keys[1], spawnPoints[secondKeyLoc].transform.position, spawnPoints[secondKeyLoc].transform.rotation);
        Instantiate(keys[2], spawnPoints[thirdKeyLoc].transform.position, spawnPoints[thirdKeyLoc].transform.rotation);
    }

}
