using UnityEngine;

namespace HinosPackage.Runtime.Components.Movement {
    public abstract class MovementComponent : MonoBehaviour {
        [SerializeField] protected float speed = 5f;
        
        [Header("Jump Attributes")]
        [SerializeField] protected float jumpHeight = 3f;
        [SerializeField] protected float footOffset = .4f;
        [SerializeField] protected float groundCheckDistance = .2f;

        protected Transform _transform;
        
        protected bool jumpRequest;
        protected bool isGrounded;
        
        protected virtual void Awake() {
            _transform = GetComponent<Transform>();
        }

        protected virtual void FixedUpdate() {
            CheckPhysics();
            //ProcessMove(_inputProvider.HorizontalAxisInput);
            ProcessJump();
        }
        
        protected abstract void ProcessJump();
        
        public abstract void ProcessMove(float horizontalAxisInput, float verticalAxisInput = 0);

        protected virtual void CheckPhysics() {
            var leftCheck = Raycast(new Vector2(-footOffset, 0f), Vector2.down, groundCheckDistance);
            var rightCheck = Raycast(new Vector2(footOffset, 0f), Vector2.down, groundCheckDistance);
            isGrounded = leftCheck || rightCheck;
        }

        public void SetJumpRequest() => jumpRequest = true;

        
        
        
        protected RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length) {
            var pos = (Vector2)_transform.position;
            var hit = Physics2D.Raycast(pos + offset, rayDirection, length);
            var color = hit ? Color.red : Color.green;
            Debug.DrawRay(pos + offset, rayDirection * length, color);
            return hit;
        }
    }
}