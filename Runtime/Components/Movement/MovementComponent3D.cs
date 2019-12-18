using HinosPackage.Runtime.Util;
using UnityEngine;

namespace HinosPackage.Runtime.Components.Movement {
    [RequireComponent(typeof(Rigidbody))]
    public class MovementComponent3D : MovementComponent {
        private Rigidbody _rigidbody;

        protected override void Awake() { 
            base.Awake();
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        protected override void HandleMove(float horizontalAxisInput, float verticalAxisInput = 0) {
            throw new System.NotImplementedException();
        }

        protected override void HandleJump(float force) => _rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}