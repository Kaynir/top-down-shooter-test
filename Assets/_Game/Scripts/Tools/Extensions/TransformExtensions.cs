using UnityEngine;

namespace Kaynir.TDSTest.Tools.Extensions
{
    public static class TransformExtensions
    {
        public static Vector2 DirectionTo(this Transform origin, Transform target)
        {
            return target.position - origin.position;
        }

        public static Vector2 DirectionToNormalized(this Transform origin, Transform target)
        {
            return DirectionTo(origin, target).normalized;
        }

        public static Vector2 PositionFromAngle(this Transform origin, float angle)
        {
            angle *= Mathf.Deg2Rad;
            return origin.position + new Vector3(Mathf.Sin(angle), Mathf.Cos(angle));
        }

        public static float DistanceTo(this Transform origin, Transform target)
        {
            return Vector2.Distance(origin.position, target.position);
        }

        public static bool InAngleWith(this Transform origin, Transform target, float angle)
        {
            Vector2 direction = origin.DirectionTo(target);
            return InAngleWith(origin, direction, angle);
        }

        public static bool InAngleWith(this Transform origin, Vector2 direction, float angle)
        {
            return Vector2.Angle(origin.up, direction) <= angle * .5f;
        }
    }
}