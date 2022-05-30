using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChamberPoint : MonoBehaviour
{
    //Death chamber, death chamber, death chamber
    //Ya damn right, Knuckles

    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(0, 1, 0);
            Debug.Log("entered");
        }
    }
}
