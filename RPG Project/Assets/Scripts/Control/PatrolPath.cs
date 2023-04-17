using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
=======
using UnityEditor;
>>>>>>> Stashed changes
using UnityEngine;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {
<<<<<<< Updated upstream
        const float waypointGizmoRadius = 0.3f;

        private void OnDrawGizmos() {
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(GetWaypoint(i), waypointGizmoRadius);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
=======
        const float waypointRadius = 0.3f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            for(int i = 0; i < transform.childCount; i++)
            {
                
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(GetWaypoint(i), waypointRadius);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));

                //Gizmos.DrawLine(GetWaypoint(0), GetWaypoint(int.MaxValue));
>>>>>>> Stashed changes
            }
        }

        public int GetNextIndex(int i)
        {
<<<<<<< Updated upstream
            if (i + 1 == transform.childCount)
=======
            if(i + 1 == transform.childCount)
>>>>>>> Stashed changes
            {
                return 0;
            }
            return i + 1;
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
