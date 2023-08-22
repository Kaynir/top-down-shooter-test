using System;
using System.Collections.Generic;
using System.Linq;
using Kaynir.TDSTest.Detection.Rules;
using Kaynir.TDSTest.Tools.Extensions;
using UnityEngine;

namespace Kaynir.TDSTest.Detection
{
    public class FieldOfView : MonoBehaviour
    {
        [Header("View Settings:")]
        [SerializeField] private float viewRadius = 5f;
        [SerializeField, Range(0f, 360f)] private float viewAngle = 45f;

        [Header("Detection Settings:")]
        [SerializeField] private LayerMask viewMask = 0;
        [SerializeField] private RaycastDetectionRule obstacleRule = null;
        [SerializeField] private List<DetectionRule> optionalRules = new List<DetectionRule>();

        public float ViewRadius => viewRadius;
        public float ViewAngle => viewAngle;

        public RaycastDetectionRule ObstacleRule => obstacleRule;

        public bool TryGetVisibleTargets(out IEnumerable<Collider2D> targets)
        {
            Collider2D[] colliders = GetOverlapColliders();

            if (colliders.Length == 0)
            {
                targets = Enumerable.Empty<Collider2D>();
                return false;
            }

            Transform origin = transform;

            targets = colliders.Where(c => origin.InAngleWith(c.transform, viewAngle))
                               .Where(c => obstacleRule.IsVisibleTarget(c, this))
                               .Where(c => IsVisibleForOptionalRules(c));

            return targets.Count() > 0;
        }

        public bool TryGetVisibleTarget(out Collider2D target)
        {
            TryGetVisibleTargets(out var targets);
            target = targets.FirstOrDefault();
            return target;
        }

        private Collider2D[] GetOverlapColliders()
        {
            return Physics2D.OverlapCircleAll(transform.position,
                                              viewRadius,
                                              viewMask);
        }

        private bool IsVisibleForOptionalRules(Collider2D target)
        {
            if (optionalRules.Count == 0) return true;
            return optionalRules.Any(c => c.IsVisibleTarget(target, this));
        }
    }
}