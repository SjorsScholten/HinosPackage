namespace HinosPackage.Runtime.TempFiles {
    public class TempRegeneration {
        /*
        [SerializeField] private bool regenerateHealth = false;
        [SerializeField] private float healthRegenerationStartTime = 2f;
        [SerializeField] private float healthRegenerationAmount = 10f;
        [SerializeField] private float healthRegenerationTick = 1f;
        */
        
        //private IEnumerator _regenerationCouroutine;
        
        //private bool _isRegenerating = false;
        
        /*
        private void StartHealthRegeneration() {
            if (_isRegenerating) StopHealthRegenerating();
        
            _regenerationCouroutine = HealthRegenerating();
        
            StartCoroutine(_regenerationCouroutine);
            _isRegenerating = true;
        }

        private void StopHealthRegenerating() {
            if (!_isRegenerating) return;
        
            StopCoroutine(_regenerationCouroutine);
            _isRegenerating = false;
        }

        private IEnumerator HealthRegenerating() {
            yield return new WaitForSeconds(healthRegenerationStartTime);
            while (!health.Satisfied) {
                health.Value += healthRegenerationAmount;
                yield return new WaitForSeconds(healthRegenerationTick);
            }
        }
        */
    }
}