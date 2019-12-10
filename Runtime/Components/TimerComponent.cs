using HinosPackage.Runtime.Util;
using HinosPackage.Runtime.Util.Timers;
using UnityEngine;
using UnityEngine.Events;

namespace HinosPackage.Runtime.Components {
    public class TimerComponent : MonoBehaviour, ITimerCallbacks {
        [SerializeField] private Timer timer = new Timer();

        [SerializeField] private bool startAtBeginning = false;
        
        public UnityEvent onTick = new UnityEvent();
        public UnityEvent onTimerStart = new UnityEvent();
        public UnityEvent onTimerEnd = new UnityEvent();

        private void Start() {
            if(startAtBeginning) StartTimer();
        }

        private void OnEnable() => timer.SetCallbacks(this);

        private void OnDisable() => timer.RemoveCallbacks(this);

        private void Update() => timer.Update(Time.deltaTime);

        public void StartTimer() => timer.Start();

        public void PauseTimer() => timer.Pause();

        public void ResetTimer() => timer.Reset();

        public void StopTimer() => timer.Stop();

        public float SecondsTime => timer.CurrentTime;
        
        public void OnTimerStart() => onTimerStart?.Invoke();

        public void OnTimerEnd() => onTimerEnd?.Invoke();

        public void OnTimerTick() => onTick?.Invoke();
    }
}