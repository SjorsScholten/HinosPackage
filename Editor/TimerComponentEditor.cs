using HinosPackage.Runtime.Components;
using UnityEditor;
using UnityEngine;

namespace HinosPackage.Editor {
    [CustomEditor(typeof(TimerComponent))]
    public class TimerComponentEditor : UnityEditor.Editor{
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;
            
            var timer = target as TimerComponent;

            if (!timer) return;
            if (GUILayout.Button("Start")) timer.StartTimer();
            if (GUILayout.Button("Pause")) timer.PauseTimer();
            if (GUILayout.Button("Reset")) timer.ResetTimer();
            if (GUILayout.Button("Stop")) timer.StopTimer();
        }
    }
}