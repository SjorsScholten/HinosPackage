﻿using System;
using HinosPackage.Runtime.Util;
using HinosPackage.Runtime.Util.Timers;
using UnityEngine;

namespace HinosPackage.Runtime.Systems {
    public class ScoreManager : MonoBehaviour {
        public float Score { get; private set; } = 0;
        public float Combo { get; private set; } = 0;

        public Timer comboTimer = new Timer(1, true);

        public event Action OnScoreChanged;

        private void Awake() {
            comboTimer.OnTimerStart += ResetCombo;
        }

        private void Start() {
            Score = 0f;
            OnScoreChanged?.Invoke();
        }

        private void Update() => comboTimer.Update(Time.deltaTime);

        public void AddScore(float value) {
            Score += value;
        
            comboTimer.Reset();
            if(!comboTimer.IsAwake) comboTimer.Start();
            Combo += value;
        
            OnScoreChanged?.Invoke();
        }

        private void ResetCombo() => Combo = 0;

        [ContextMenu("TestScore")]
        public void TestScore() => AddScore(10);
    }
}