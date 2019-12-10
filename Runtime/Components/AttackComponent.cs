using HinosPackage.Runtime.ScriptableObjects.Attack;
using UnityEngine;
using UnityEngine.Events;

namespace HinosPackage.Runtime.Components {
    public class AttackComponent : MonoBehaviour {
        [SerializeField] private Attack attack = null;
        [SerializeField] private Vector2 offset = new Vector2(0f,1f);
        
        private Transform _transform;
        
        public UnityEvent OnAttack = new UnityEvent();

        private void Awake() {
            _transform = GetComponent<Transform>();
        }

        public void ProcessAttack(Vector2 direction) {
            var initialPosition = (Vector2)_transform.position + offset;
            var initialDirection = (direction - initialPosition).normalized;
            
            attack.HandleAttack(initialPosition, initialDirection, gameObject.layer);
            
            OnAttack?.Invoke();
        }
    }
}
