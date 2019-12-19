using System;
using UnityEngine;

namespace HinosPackage.Runtime.Util {
    [Serializable]
    public class Resource {
        [SerializeField] private float initialValue = 0f;
        [SerializeField] private float minValue = 0f;
        [SerializeField] private float maxValue = 1f;

        private float currentValue = 0f;

        public event Action OnValueChanged;

        public Resource(float initialValue, float minValue, float maxValue) {
            this.initialValue = initialValue;
            this.minValue = minValue;
            this.maxValue = maxValue;
            
            Value = initialValue;
        }
        
        public float Value {
            get => currentValue;
            set => currentValue = Mathf.Clamp(currentValue + value, minValue, maxValue);
        }

        public float Percent => (currentValue - minValue) / (maxValue - minValue);

        public bool Satisfied => currentValue == maxValue;
        public bool Depleted => currentValue == minValue;
    }
}