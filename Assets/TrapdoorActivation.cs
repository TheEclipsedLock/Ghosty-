using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorActivation : MonoBehaviour
{
    public GameObject trapdoor1;

    public GameObject trapdoor2;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trapdoor1.GetComponent<Rigidbody>().useGravity = true;
            trapdoor1.GetComponent<Rigidbody>().isKinematic = false;
            trapdoor2.GetComponent<Rigidbody>().useGravity = true;
            trapdoor2.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Exited");
        }
    }
}
