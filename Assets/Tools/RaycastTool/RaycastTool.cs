using UnityEngine;

namespace BrainlessPet.Tools
{
    public class RaycastTool : MonoBehaviour, IRaySelector
    {
        [SerializeField] private LayerMask layerMask;
        [Tooltip("Can be change in code for different objects by SetDistance before using check")]
        [SerializeField] private float maxDistance;
        [SerializeField] private float debugRayDuration;
        private Transform selection;

        public float SetDistance { set => maxDistance = value; }

        public void CheckRay(Ray ray)
        {
            selection = null;

            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
            {
                selection = hit.transform;
            }

            DebugMode(ray.origin, ray.direction);
        }

        public void CheckRay2D(Ray2D ray2D)
        {
            selection = null;
            RaycastHit2D hit2D;
            
            hit2D = Physics2D.Raycast(ray2D.origin, ray2D.direction, maxDistance, layerMask);

            selection = hit2D ? hit2D.transform : selection;

            DebugMode(ray2D.origin, ray2D.direction);
        }

        public Transform GetSelection()
        {
            return selection;
        }

#if UNITY_EDITOR
        private void DebugMode(Vector3 startPoint, Vector3 direction)
        {
            Debug.DrawRay(startPoint, direction * maxDistance, Color.red, debugRayDuration);
        }
#endif
    }
}