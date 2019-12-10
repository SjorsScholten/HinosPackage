using HinosPackage.Runtime.Util.Events;
using UnityEngine;

namespace HinosPackage.Runtime.Components {
    public class InputComponent : MonoBehaviour {
        [SerializeField] private SignalListener[] signalListeners = new SignalListener[0];

        private void OnEnable() {
            foreach (var listener in signalListeners) listener.Enable();
        }

        private void OnDisable() {
            foreach (var listener in signalListeners) listener.Disable();
        }
    }
}
