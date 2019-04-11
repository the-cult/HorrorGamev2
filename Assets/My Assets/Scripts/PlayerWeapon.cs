using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject weapon;
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Destroy(other.gameObject);
            Instantiate(weapon, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
