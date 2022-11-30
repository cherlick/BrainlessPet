using UnityEngine;
using BrainlessPet.Scriptables;

namespace BrainlessPet.Characters
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private FloatReference platformSpeed;
        [SerializeField] private FloatReference stopDistance;
        [SerializeField] private FloatReference waypointWatingTime;
        private float timeCounting;

        private Transform targetWaypoint;
        private int currentWaypointIndex;

        public float PlatformSpeed => platformSpeed.Value;

        private void Start() 
        {
            targetWaypoint = wayPoints[0];
            timeCounting = waypointWatingTime.Value;
        }

        private void Update() 
        {
            if (timeCounting <=0)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, platformSpeed.Value * Time.deltaTime);
            }
            
            if (Vector2.Distance(transform.position, targetWaypoint.position) <= stopDistance.Value)
            {
                targetWaypoint = GetNextWayPoint();
                timeCounting = waypointWatingTime.Value;
            }

            if (timeCounting > 0)
            {
                timeCounting -= Time.fixedDeltaTime ;
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

