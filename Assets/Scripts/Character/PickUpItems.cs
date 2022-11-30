using System;
using System.Collections;
using System.Collections.Generic;
using BrainlessPet.Scriptables;
using BrainlessPet.Tools;
using UnityEngine;

namespace BrainlessPet.Items
{
    
    public class PickUpItems : MonoBehaviour
    {
        
        [SerializeField] private FloatReference characterXDirection;
        private Vector2 direction = Vector2.right;
        private IRaySelector raySelector;

        private void Awake() 
        {
            raySelector = GetComponent<IRaySelector>();
        }

        private void Update() 
        {
            CheckCollision();
        }

        private void CheckCollision()
        {
            direction.x = characterXDirection.Value;
            raySelector.CheckRay2D(new Ray2D(transform.position, direction));
            var otherObject = raySelector.GetSelection();

            if (otherObject != null)
            {
                if (otherObject.CompareTag("Item"))
                {
                    var pickedItem = otherObject.GetComponent<Item>();
                    
                    if (pickedItem != null)
                    {
                        pickedItem.PickedItem();
                        pickedItem.transform.SetParent(this.transform);
                    }   
                }
            }
        }
    }
}

