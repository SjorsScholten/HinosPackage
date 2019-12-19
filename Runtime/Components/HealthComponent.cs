using System;
using System.Collections;
using HinosPackage.Runtime.Util;
using UnityEngine;
using UnityEngine.Events;

namespace HinosPackage.Runtime.Components {
    public class HealthComponent : MonoBehaviour {
        [SerializeField] private Resource health  = new Resource(100f, 0f, 100f);
        [SerializeField] private Resource temporaryHealth = new Resource(0f, 0f, 150f);

        public UnityEvent onDamage = new UnityEvent();
        public UnityEvent onDeath = new UnityEvent();

        //flags
        private bool _isDead = false;

        public void TakeDamage(float damage) {
            if (damage < 0 || _isDead) return;
        
            health.Value -= damage;
        
            if (health.Depleted) {
                Die();
                return;
            }
            
            onDamage?.Invoke();
        }

        public void Heal(float value) {
            if (value < 0) return;
        
            //if (CurrentHealth + value > initialHealth) CurrentHealth = initialHealth;
            //else CurrentHealth += value;
        }

        private void Die() {
            if (_isDead) return;
            _isDead = true;
            onDeath.Invoke();
            Destroy(this.gameObject);
        }


        public float TotalHealth => health.Value + temporaryHealth.Value;
    }
}