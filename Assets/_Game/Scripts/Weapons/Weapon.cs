using Kaynir.TDSTest.Damageables;
using Kaynir.TDSTest.Detection.Rules;
using UnityEngine;

namespace Kaynir.TDSTest.Weapons
{
    public class Weapon : MonoBehaviour
    {
        // base class to orginize modular weapons with composition and strategies
        // for example, IAttackHandler, IReloadHandler, etc.
        // it allows to create both melee and range weapons
        // for test i used simple hit scan implementation

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