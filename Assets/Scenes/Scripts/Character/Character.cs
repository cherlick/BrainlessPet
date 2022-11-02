using System;
using BrainlessPet.Scriptables;
using BrainlessPet.Tools;
using UnityEngine;

namespace BrainlessPet.Characters
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO onDeath;
        [SerializeField] private VoidEventChannelSO onEnterGate;
        [SerializeField] private float yLimitToDeath;
        [SerializeField] private FloatReference yVelocity;
        [SerializeField] private FloatReference xDirection;
        [SerializeField] private BoolReference isGrounded;
        [SerializeField] private float distanceToGroundCheck;
        private IRaySelector selector;
        private Vector2 direction = Vector2.right;
        private Vector2 groundDirectionCheck = Vector2.down;
        private float prevYVelocity;

        public bool IsGrounded { get => isGrounded.Value; }

        private void Awake() 
        {
            selector = GetComponent<IRaySelector>();
            xDirection.Variable.Value = direction.x;
        }

        private void Update() 
        {
            UpdateVariables();
            CheckLimitsDeath();
            CheckCollision();
            CheckGround();
        }

        private void CheckLimitsDeath()
        {
            if (transform.position.y < yLimitToDeath)
            {
                onDeath.RaiseEvent();
            }
        }

        private void UpdateVariables()
        {
            direction.x = xDirection.Value;
        }

        private void CheckCollision()
        {
            selector.ResetDistance();
            selector.CheckRay2D(new Ray2D(transform.position, direction));
            var otherObject = selector.GetSelection();

            if (otherObject != null)
            {
                if (otherObject.CompareTag("Walls"))
                {
                    ChangeDirection();
                }
                if (otherObject.CompareTag("Gate"))
                {
                    onEnterGate.RaiseEvent();
                }
            }
        }

        private void CheckGround()
        {
            selector.SetDistance = distanceToGroundCheck;
            selector.CheckRay2D(new Ray2D(transform.position, groundDirectionCheck));
            var otherObject = selector.GetSelection();

            if (otherObject != null)
            {
                if (otherObject.CompareTag("Ground"))
                {
                    isGrounded.Variable.Value = true;
                    if (prevYVelocity < -15f)
                    {
                        onDeath.RaiseEvent();
                    }
                }
                else
                {
                    isGrounded.Variable.Value = false;
                    if (yVelocity.Value != 0)
                    {
                        prevYVelocity = yVelocity.Value;
                    }
                    
                    
                }
            }
            else
            {
                isGrounded.Variable.Value = false;
                if (yVelocity.Value != 0)
                {
                    prevYVelocity = yVelocity.Value;
                }
            }
        }

        private void ChangeDirection()
        {
            xDirection.Variable.Value *=-1;
            transform.localScale = new Vector3(direction.x, 1, 1);
        }
       
    }
}

