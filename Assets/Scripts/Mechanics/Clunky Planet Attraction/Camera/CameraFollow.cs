using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player = null;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player) GetComponent<CameraFollow>().enabled = false;
    }
    void Update()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y, -10);
    }
}
