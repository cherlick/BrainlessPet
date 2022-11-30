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
        [SerializeField] private float fallSpeedToDeath = -15f;
        [SerializeField] private FloatReference yVelocity;
        [SerializeField] private FloatReference xDirection;
        [SerializeField] private FloatReference movementSpeed;
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
                    CheckDeathByFall();
                }

                else if (otherObject.CompareTag("MovingPlatform"))
                {
                    isGrounded.Variable.Value = true;
                    CheckDeathByFall();

                    EnteringMovingPlatforms(otherObject);
                }
                else
                {
                    isGrounded.Variable.Value = false;

                    if (yVelocity.Value != 0)
                    {
                        prevYVelocity = yVelocity.Value;
                    }

                    ExitingMovingPlatforms();
                }
            }
            else
            {
                if (transform.parent != null)
                {
                    ExitingMovingPlatforms();
                }
                
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
            transform.localScale = new Vector3(direction.x, transform.localScale.y, transform.localScale.z);
        }

        private void CheckDeathByFall()
        {
            if (prevYVelocity < fallSpeedToDeath)
            {
                onDeath.RaiseEvent();
            }
        }

        private void EnteringMovingPlatforms(Transform platform)
        {
            
            if (movementSpeed.Value == 0 )
            {
                if (transform.parent != platform)
                {
                    transform.SetParent(platform);
                }
            }
        }

        private void ExitingMovingPlatforms()
        {
            transform.SetParent(null);
        }
       
    }
}

