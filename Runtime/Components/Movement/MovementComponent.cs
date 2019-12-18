using System;
using HinosPackage.Runtime.Util;
using UnityEngine;

namespace HinosPackage.Runtime.Components.Movement {
    public abstract class MovementComponent : MonoBehaviour {
        [SerializeField] protected float speed = 5f;
        
        [Header("Jump Attributes")]
        [SerializeField] protected JumpForce jumpForce = new JumpForce();
        [SerializeField] private float footOffset = .4f;
        [SerializeField] private float groundCheckDistance = .2f;

        private Transform _transform;

        private bool jumpRequest;
        private bool isGrounded;
        
        [Serializable] protected class JumpForce : DirtyProp<float> {
            [SerializeField] private float jumpHeight = 2f, mass = 1f;

            public float JumpHeight {
                get => jumpHeight;
                set {
                    jumpHeight = value;
                    isDirty = true;
                }
            }

            public float Mass {
                get => mass;
                set {
                    mass = value;
                    isDirty = true;
                }
            }
            
            protected override float CalculateFinalValue() => Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight) * mass;
        }
        
        protected virtual void Awake() {
            _transform = GetComponent<Transform>();
        }

        protected virtual void FixedUpdate() {
            CheckPhysics();
            
            //ProcessMove(_inputProvider.HorizontalAxisInput);
            ProcessJump();
        }
        
        protected virtual void CheckPhysics() {
            var leftCheck = Raycast(new Vector2(-footOffset, 0f), Vector2.down, groundCheckDistance);
            var rightCheck = Raycast(new Vector2(footOffset, 0f), Vector2.down, groundCheckDistance);
            isGrounded = leftCheck || rightCheck;
            isGrounded = true;
        }

        private void ProcessJump() {
            if(!jumpRequest || !isGrounded) return;
            HandleJump(jumpForce.Value);
            jumpRequest = false;
        }

        protected RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length) {
            var pos = (Vector2)_transform.position + offset;
            var hit = Physics2D.Raycast(pos, rayDirection, length);
            var color = hit ? Color.red : Color.green;
            Debug.DrawRay(pos, rayDirection * length, color);
            return hit;
        }

        protected abstract void HandleMove(float horizontalAxisInput, float verticalAxisInput = 0);
        protected abstract void HandleJump(float force);

        [ContextMenu("test Jump")]
        public void RequestJump() => jumpRequest = true;

    }
}