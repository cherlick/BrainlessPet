using BrainlessPet.Actions;
using System.Collections;
using BrainlessPet.Tools;
using UnityEngine;

namespace BrainlessPet.Characters
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2DRef;
        [SerializeField] private MovementController movementController;
        [SerializeField] private ScriptableActions onDeath;
        [SerializeField] private ScriptableActions onEnterGate;
        [SerializeField] private float yLimitToDeath;
        private IRaySelector selector;
        private Vector2 direction = Vector2.right;

        private void Awake() 
        {
            selector = GetComponent<IRaySelector>();
        }

        private void Update() 
        {
            if (transform.position.y < yLimitToDeath)
            {
                onDeath.Raise();
            }
            
            CheckCollision();
            movementController.Move(direction);

           /* if (Input.GetKeyDown(KeyCode.W))
            {
                movementController.Jump();
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                movementController.StartFall();
            }*/
        }

        private void CheckCollision()
        {
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
                    onEnterGate.Raise();
                }
            }
        }

        private void ChangeDirection()
        {
            direction *=-1;
            transform.localScale = new Vector3(direction.x, 1, 1);
        }
       
    }
}

