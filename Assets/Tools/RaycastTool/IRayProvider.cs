using UnityEngine;

namespace BrainlessPet.Tools
{
    public interface IRayProvider
    {
        Ray CreateRay(Transform castFrom);
        Ray2D Create2DRay(Transform castFrom);
        Ray CreateRayFromCam();
    }
}
