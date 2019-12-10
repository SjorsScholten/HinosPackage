using HinosPackage.Runtime.Components;
using UnityEditor;
using UnityEngine;

namespace HinosPackage.Editor {
    [CustomEditor(typeof(SpawnComponent))]
    public class SpawnComponentEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;
            
            var e = target as SpawnComponent;
            
            if (GUILayout.Button("Spawn new Entity")) {
                if (e != null) e.SpawnPrefab();
            }
        }
    }
}