using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GhostFieldOfView))]
public class GhostFieldOfViewEditor : Editor
{
    //Whenever the GhostFieldOfView is active, this editor will start running
    private void OnSceneGUI()
    {
        //Set to target of this editor, casted to the script
        GhostFieldOfView gFOV = (GhostFieldOfView)target;
        Handles.color = Color.white;

        //Draws the radius around the enemy
        Handles.DrawWireArc(gFOV.transform.position, Vector3.up, Vector3.forward, 360, gFOV.enemyRadius);

        Vector3 viewAngle1 = DirectionFromAngle(gFOV.transform.eulerAngles.y, -gFOV.angleOfView / 2);
        Vector3 viewAngle2 = DirectionFromAngle(gFOV.transform.eulerAngles.y, gFOV.angleOfView / 2);

        //Draw in the two angles
        Handles.color = Color.yellow;
        Handles.DrawLine(gFOV.transform.position, gFOV.transform.position + viewAngle1 * gFOV.enemyRadius);
        Handles.DrawLine(gFOV.transform.position, gFOV.transform.position + viewAngle2 * gFOV.enemyRadius);

        if (gFOV.isSeeingPlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(gFOV.transform.position, gFOV.player.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}

