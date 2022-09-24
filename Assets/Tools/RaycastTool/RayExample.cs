using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrainlessPet.Tools
{
    
    public class RayExample : MonoBehaviour
    {
        private IRaySelector selector;

        private void Awake() 
        {
            selector = GetComponent<IRaySelector>();
        }

        private void Update() 
        {
            if (selector != null)
            {
                selector.SetDistance = 5f;
                selector.CheckRay2D(new Ray2D(transform.position, transform.right));
            }
            
            Debug.Log(selector.GetSelection());
        }
    }

}

