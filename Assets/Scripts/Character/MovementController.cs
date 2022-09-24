using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrainlessPet.Characters.Pets;

namespace BrainlessPet.Characters
{
    public class MovementController : MonoBehaviour, ICommandable
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 10f;
        private Rigidbody2D rigidbody2DRef;
        private float currentSpeed;

        public float CurrentModifierValue { get => currentSpeed; set => currentSpeed = value; }

        private void OnValidate() 
        {
            ResetCurrentSpeed();
        }

        private void Awake() 
        {
            rigidbody2DRef = rigidbody2DRef == null ? GetComponent<Rigidbody2D>() : rigidbody2DRef;
            ResetCurrentSpeed();
        }

        public void Move(Vector2 direction)
        {
            if (rigidbody2DRef == null) 
            {
                Debug.LogWarning("Rigidbody2D NotFound");
                return;
            }
            Vector3 currentl = Vector3.zero;
            Vector2 targetVelocity = new Vector2(direction.x * currentSpeed, rigidbody2DRef.velocity.y);
            rigidbody2DRef.velocity = targetVelocity;
        }

        /*public void Jump()
        {
            Vector2 targetVelocity = new Vector2(rigidbody2DRef.velocity.x, rigidbody2DRef.velocity.y + jumpForce);
            rigidbody2DRef.AddForce(targetVelocity, ForceMode2D.Impulse);
        }

        public void StartFall()
        {
            Vector2 targetVelocity = new Vector2(rigidbody2DRef.velocity.x, rigidbody2DRef.velocity.y *-1);
            rigidbody2DRef.AddForce(targetVelocity, ForceMode2D.Impulse);
        }*/

        private void ResetCurrentSpeed() => currentSpeed = moveSpeed;
        private void ResetModifiers()
        {
            StopAllCoroutines();
            ResetCurrentSpeed();
        }
        public void ResetCommand()
        {
            ResetModifiers();
        }
    }
}

