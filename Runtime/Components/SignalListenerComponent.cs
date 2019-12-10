using System;
using HinosPackage.Runtime.Systems.Events;
using HinosPackage.Runtime.Util.Events;
using UnityEngine;

namespace HinosPackage.Runtime.Components {
    public class SignalListenerComponent : MonoBehaviour {
        [SerializeField] private SignalListener signalListener;

        private void OnEnable() => signalListener.Enable();
        private void OnDisable() => signalListener.Disable();
    }
}