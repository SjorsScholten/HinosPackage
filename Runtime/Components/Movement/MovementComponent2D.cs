using UnityEngine;

namespace HinosPackage.Runtime.Components.Movement {
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent2D : MovementComponent {
        private Rigidbody2D _rigidbody2D;

        protected override void Awake() { 
            base.Awake();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected override void HandleMove(float horizontalAxisInput, float verticalAxisInput = 0) {
            var direction2D = new Vector2(horizontalAxisInput, verticalAxisInput);
            var horizontalSpeed = direction2D.x * speed;
            _rigidbody2D.velocity = new Vector2(horizontalSpeed, _rigidbody2D.velocity.y);
        }

        protected override void HandleJump(float force) => _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
}