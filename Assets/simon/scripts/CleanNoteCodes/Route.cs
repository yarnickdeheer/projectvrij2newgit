using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField]
    public Transform[] controlPoints;

    private Vector3 gizmosPosition;



    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position + 3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position + 3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position + Mathf.Pow(t, 3) * controlPoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);

            Vector3 nextGizmoPos = Mathf.Pow(1 - (t + 0.05f), 3) * controlPoints[0].position + 3 * Mathf.Pow(1 - (t + 0.05f), 2) * (t + 0.05f) * controlPoints[1].position + 3 * (1 - (t + 0.05f)) * Mathf.Pow((t + 0.05f), 2) * controlPoints[2].position + Mathf.Pow((t + 0.05f), 3) * controlPoints[3].position;
            //Vector3 forward = nextGizmoPos - gizmosPosition;
            //Vector3 Right = Vector3.Cross(Vector3.up, forward);

            //Gizmos.DrawSphere(gizmosPosition + Right * 2, 0.25f);
            //Gizmos.DrawSphere(gizmosPosition - Right * 2, 0.25f);

        }
        Gizmos.DrawLine(new Vector3(controlPoints[0].position.x, controlPoints[0].position.y, controlPoints[0].position.z), new Vector3(controlPoints[1].position.x, controlPoints[1].position.y, controlPoints[1].position.z));
        Gizmos.DrawLine(new Vector3(controlPoints[2].position.x, controlPoints[2].position.y, controlPoints[2].position.z), new Vector3(controlPoints[3].position.x, controlPoints[3].position.y, controlPoints[3].position.z));
    }
}

