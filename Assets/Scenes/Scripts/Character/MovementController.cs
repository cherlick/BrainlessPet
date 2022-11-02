using UnityEngine;
using BrainlessPet.Scriptables;

namespace BrainlessPet.Characters
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private FloatReference moveSpeed;
        [SerializeField] private FloatReference yVelocity;
        [SerializeField] private BoolReference isYVelocityChanged;
        [SerializeField] private FloatReference xDirection;
        [SerializeField] private Rigidbody2D rigidbody2DRef;

        private void Awake() 
        {
            rigidbody2DRef = rigidbody2DRef == null ? GetComponent<Rigidbody2D>() : rigidbody2DRef;
        }

        private void Update() 
        {
            if (isYVelocityChanged.Value == false)
            {
                yVelocity.Variable.Value = rigidbody2DRef.velocity.y;
            }
            Move();
        }

        private void Move()
        {
            
            if (rigidbody2DRef == null) 
            {
                Debug.LogWarning("Rigidbody2D NotFound");
                return;
            }
            
            Vector2 targetVelocity = new Vector2(xDirection.Value * moveSpeed.Value, yVelocity.Value);
            rigidbody2DRef.velocity = targetVelocity;
        }
    }
}

