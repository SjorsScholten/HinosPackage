using System;
using UnityEngine;

namespace HinosPackage.Runtime.Util {
    public class Resource {
        [SerializeField] private float initialValue = 0f;
        [SerializeField] private float minValue = 10f;
        [SerializeField] private float maxValue = -10f;

        private float currentValue = 0f;
        public float Value {
            get => currentValue;
            private set { currentValue = Mathf.Clamp(currentValue - value, minValue, maxValue); }
        }

        public event Action OnValueChanged;

        public Resource(float initialValue) {
            this.initialValue = initialValue;
            Value = initialValue;
        }

        public void AddAmount(float value) {
            if (value <= 0) return;
            
        }
        
        public void RemoveAmount(float value) {
            if(value >= 0) return;
        }
    }
}