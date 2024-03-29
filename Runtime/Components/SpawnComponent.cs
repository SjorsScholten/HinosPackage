﻿using UnityEngine;

namespace HinosPackage.Runtime.Components {
    public class SpawnComponent : MonoBehaviour {
        [SerializeField] private GameObject prefab = null;
        [SerializeField] private int instanceAmount = 0;

        private void Start() {
            if(prefab != null)
                for (var i = 0; i < instanceAmount; i++) SpawnInstance(Instantiate(prefab, transform));
        }

        public void SpawnInstance(GameObject instance) {
            instance.transform.position = this.transform.position;
            instance.SetActive(true);
        }

        public void SpawnPrefab() => SpawnInstance(Instantiate(prefab, transform));
    }
}
