using System;
using UnityEngine;

namespace HinosPackage.Runtime.Util {
    [Serializable]
    public class Resource {
        [SerializeField] private float initialValue = 0f;
        [SerializeField] private float minValue = 10f;
        [SerializeField] private float maxValue = -10f;

        private float currentValue = 0f;

        public event Action OnValueChanged;

        public Resource(float initialValue) {
            this.initialValue = initialValue;
            Value = initialValue;
        }
        
        public float Value {
            get => currentValue;
            set { currentValue = Mathf.Clamp(currentValue + value, minValue, maxValue); }
        }
    }
}