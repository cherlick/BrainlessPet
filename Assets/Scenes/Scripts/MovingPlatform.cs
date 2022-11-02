using UnityEngine;
using BrainlessPet.Scriptables;

namespace BrainlessPet.Characters
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private FloatReference platformSpeed;
        [SerializeField] private FloatReference checkDistance;

        private Transform targetWaypoint;
        private int currentWaypointIndex;

        private void Start() 
        {
            targetWaypoint = wayPoints[0];
        }

        private void Update() 
        {
            transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, platformSpeed.Value * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetWaypoint.position) < checkDistance.Value)
            {
                targetWaypoint = GetNextWayPoint();
            }
        }

        private Transform GetNextWayPoint()
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }

            return wayPoints[currentWaypointIndex];
        }
    }
}

