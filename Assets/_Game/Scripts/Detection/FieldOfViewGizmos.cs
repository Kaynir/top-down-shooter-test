using Kaynir.TDSTest.Tools.Math;
using UnityEngine;

namespace Kaynir.TDSTest.Detection
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(FieldOfView))]
    public class FieldOfViewGizmos : MonoBehaviour
    {
        [Header("View Radius:")]
        [SerializeField] private bool drawViewRadius = true;
        [SerializeField] private Color sphereColor = new Color(1f, .8f, 0f, .1f);

        [Header("View Angle:")]
        [SerializeField] private bool drawViewAngle = true;
        [SerializeField, Min(2)] private int lineResolution = 2;
        [SerializeField] private Color lineColor = new Color(1f, 1f, 0f, 1f);

        private FieldOfView fov;

        private void Awake()
        {
            fov = GetComponent<FieldOfView>();
        }

        private void OnDrawGizmos()
        {
            Vector2 origin = fov.transform.position;

            if (drawViewRadius)
            {
                Gizmos.color = sphereColor;
                Gizmos.DrawSphere(origin, fov.ViewRadius);
            }

            if (drawViewAngle)
            {
                Gizmos.color = lineColor;

                float angle = transform.eulerAngles.z + fov.ViewAngle * .5f;
                float angleStep = fov.ViewAngle / (lineResolution - 1);

                for (int i = 0; i < lineResolution; i++)
                {
                    Vector2 direction = MathTools.VectorFromAngle(-angle);
                    RaycastHit2D hit = fov.ObstacleRule.GetRaycast(origin, direction, fov.ViewRadius);
                    float distance = hit ? hit.distance : fov.ViewRadius;

                    Gizmos.DrawLine(origin, origin + direction * distance);
                    
                    angle -= angleStep;
                }
            }
        }
    }
}