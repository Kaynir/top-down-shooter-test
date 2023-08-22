using UnityEngine;

namespace Kaynir.TDSTest.Detection.Rules
{
    [CreateAssetMenu(menuName = ASSET_MENU_PATH + "Stealth Rule")]
    public class StealthDetectionRule : DetectionRule
    {
        public override bool IsVisibleTarget(Collider2D target, FieldOfView view)
        {
            return target.attachedRigidbody.TryGetComponent(out IDetectable detectable)
                   && !detectable.InStealth;
        }
    }
}