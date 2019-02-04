using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject teleportObject;

    public Transform tpLocation;

    private int count;

    private void Start()
    {
        count = GameObject.Find("Player").GetComponent<PlayerController>().count;
    }

    private void Update()
    {
        count = GameObject.Find("Player").GetComponent<PlayerController>().count;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && count == 12)
        {
            teleportObject.transform.position = tpLocation.transform.position;
            GameObject.Find("Player").GetComponent<PlayerController>().count = 0;
            GameObject.Find("Player").GetComponent<PlayerController>().lives = 3;
        }
    }
}