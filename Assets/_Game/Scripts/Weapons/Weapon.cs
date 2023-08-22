using Kaynir.TDSTest.Damageables;
using Kaynir.TDSTest.Detection.Rules;
using UnityEngine;

namespace Kaynir.TDSTest.Weapons
{
    public class Weapon : MonoBehaviour
    {
        // базовый класс, организующий модульные оружия на основе композиции и стратегий
        // например, IAttackHandler, IReloadHandler и тому подобное
        // позволяет создавать как ближнее, так и дальнее оружие
        // в рамках тестового задания оружие сделано через простой хитскан
        
        [SerializeField] private RaycastDetectionRule raycastRule = null;

        public bool TryAttack()
        {
            RaycastHit2D hit = raycastRule.GetRaycast(transform.position,
                                                      transform.up,
                                                      float.PositiveInfinity);

            if (!hit) return false;
            if (!hit.rigidbody.TryGetComponent(out IKillable target)) return false;

            target.Die();
            return true;
        }
    }
}
