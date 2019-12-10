using UnityEngine;

namespace HinosPackage.Runtime.Systems.Events   {
    public class SignalOnDeath : MonoBehaviour {
        [SerializeField] private Signal onDeathSignal;

        private void Awake() {
            if(!onDeathSignal) enabled = false;
        }

        private void OnDestroy() => onDeathSignal.Raise();
    }
}