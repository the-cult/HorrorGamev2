using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    public float distance;

    private void LateUpdate()
    {
        Vector3 newPos = player.position;
        newPos.y = distance;
        transform.position = newPos;
    }

}
