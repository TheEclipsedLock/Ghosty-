using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFieldOfView : MonoBehaviour
{
    //Special thanks to https://www.youtube.com/watch?v=j1-OyLo77ss
    //Comp-3 Interactive for the tutorial on how to have a field of view.
    public float enemyRadius;

    [Range(0, 360)]
    public float angleOfView;

    public GameObject player;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool isSeeingPlayer;

    private void Start()
    {
        //Look for the player. Can be performance heavy.
        //Do inside a call routine with a delay offset. Like 5 times a second.
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);
        //We can delay our search

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        //What's actually looking for the player
        //The position of the sphere from the center position of the ghost
        //Add the radius
        //Add a layer mask to look on the layer to look for objects.
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, enemyRadius, targetMask);

        if (rangeChecks.Length != 0)
        {
            //Found something
            //Get first instance from the array. OverlapSphere should return only the player, which is the first one.
            Transform target = rangeChecks[0].transform;

            //Target from the enemy's position
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            //
            if (Vector3.Angle(transform.forward, directionToTarget) < angleOfView / 2)
            {
                //Distance the target is away from the viewing angle
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                //Start a raycast from the center of the enemy
                //then aim it to the player
                //limit it to the distance it is away from
                //stop if it hits anything in the obstructionMask
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    isSeeingPlayer = true;
                    player.transform.position = new Vector3(0, 1, 0);
                }
                else
                {
                    isSeeingPlayer = false;
                }
            }
            else
            {
                isSeeingPlayer = false;
            }
        }
        else if (isSeeingPlayer)
        {
            //If we were previously in the view and we're no longer in the view, set it back to false.
            isSeeingPlayer = false;
        }
    }
}
