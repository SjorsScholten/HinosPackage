using UnityEngine;

namespace HinosPackage.Runtime.Components.Movement {
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent2D : MovementComponent {
        
        private Rigidbody2D _rigidbody2D;

        protected override void Awake() {
            base.Awake();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public override void ProcessMove(float horizontalAxisInput, float verticalAxisInput = 0) {
            var direction2D = new Vector2(horizontalAxisInput, verticalAxisInput);
            var horizontalSpeed = direction2D.x * speed;
            _rigidbody2D.velocity = new Vector2(horizontalSpeed, _rigidbody2D.velocity.y);
        }

        protected override void ProcessJump() {
            if (!jumpRequest || !isGrounded) return;
            var force = Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight) * _rigidbody2D.mass;
            _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            jumpRequest = false;
        }
    }
}