using UnityEngine;

namespace BrainlessPet.Tools
{
    public interface IRaySelector
    {
        public void CheckRay(Ray ray);
        public void CheckRay2D(Ray2D ray2D);
        public Transform GetSelection();
        public float SetDistance { set; }
        public void ResetDistance();
    }
}
