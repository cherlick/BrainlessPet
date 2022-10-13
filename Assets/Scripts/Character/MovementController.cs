using UnityEngine;
using BrainlessPet.Characters.Pets;
using BrainlessPet.Scriptables;

namespace BrainlessPet.Characters
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private FloatReference moveSpeed;
        private Rigidbody2D rigidbody2DRef;

        private void Awake() 
        {
            rigidbody2DRef = rigidbody2DRef == null ? GetComponent<Rigidbody2D>() : rigidbody2DRef;
        }

        public void Move(Vector2 direction)
        {
            if (rigidbody2DRef == null) 
            {
                Debug.LogWarning("Rigidbody2D NotFound");
                return;
            }
            Vector3 currentl = Vector3.zero;
            Vector2 targetVelocity = new Vector2(direction.x * moveSpeed.Value, rigidbody2DRef.velocity.y);
            rigidbody2DRef.velocity = targetVelocity;
        }
    }
}

