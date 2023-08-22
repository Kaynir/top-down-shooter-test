using Kaynir.TDSTest.Tools.Extensions;
using UnityEngine;

namespace Kaynir.TDSTest.Detection.Rules
{
    [CreateAssetMenu(menuName = ASSET_MENU_PATH + "Raycast Rule")]
    public class RaycastDetectionRule : DetectionRule
    {
        [SerializeField] private LayerMask layerMask = 0;

        public override bool IsVisibleTarget(Collider2D target, FieldOfView view)
        {
            return !GetRaycast(view.transform, target.transform);
        }

        public RaycastHit2D GetRaycast(Vector2 origin, Vector2 direction, float distance)
        {
            return Physics2D.Raycast(origin, direction, distance, layerMask);
        }

        public RaycastHit2D GetRaycast(Transform origin, Transform target)
        {
            return GetRaycast(origin.position,
                              origin.DirectionTo(target),
                              origin.DistanceTo(target));
        }
    }
}