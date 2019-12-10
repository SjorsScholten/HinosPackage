using HinosPackage.Runtime.Components;
using UnityEngine;

namespace HinosPackage.Runtime.ScriptableObjects.Attack {
    
    [CreateAssetMenu]
    public class RayAttack : Attack {
        protected override void ProcessAttack(Vector2 origin, Vector2 direction, int layerMask) {
            var hit = Physics2D.Raycast(origin, direction, range, layerMask);
            
            if (!hit) return;
            
            var target = hit.transform.GetComponent<TargetComponent>();
            
            if (target) target.ProcessTakeHit(base.damage);
        }
    }
}