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
        [SerializeField] protected BoolReference isLevelReady;

        private void Awake() 
        {
            rigidbody2DRef = rigidbody2DRef == null ? GetComponent<Rigidbody2D>() : rigidbody2DRef;
        }

        private void Start() {
            rigidbody2DRef.velocity = Vector2.zero;
        }

        private void Update() 
        {
            if (!isLevelReady.Value) return;

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

            if (!isLevelReady.Value) targetVelocity = Vector2.zero;
            rigidbody2DRef.velocity = targetVelocity;
        }
    }
}

