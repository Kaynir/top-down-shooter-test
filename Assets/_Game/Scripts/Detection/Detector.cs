using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kaynir.TDSTest.Detection
{
    public class Detector : MonoBehaviour
    {
        [SerializeField] private List<FieldOfView> viewFields = new List<FieldOfView>();
        [SerializeField, Min(0f)] private float delayInSeconds = 0.5f;

        public IDetectable Target { get; private set; }
        public Vector2 LastTargetPosition { get; private set; }

        public bool HasTarget => Target != null;
        
        private float elapsedTime;

        private void Update()
        {
            if (elapsedTime < delayInSeconds)
            {
                elapsedTime += Time.deltaTime;
                return;
            }

            elapsedTime = 0f;
            CheckForTarget();
        }

        private void CheckForTarget()
        {
            Collider2D col = null;
            viewFields.FirstOrDefault(v => v.TryGetVisibleTarget(out col));

            if (!col || !col.attachedRigidbody.TryGetComponent(out IDetectable newTarget))
            {
                ClearTarget();
                return;
            }

            UpdateTarget(newTarget);
        }

        private void ClearTarget()
        {
            Target = null;
        }

        private void UpdateTarget(IDetectable newTarget)
        {
            if (!HasTarget) Target = newTarget;
            LastTargetPosition = Target.Agent.Movement.Position;
        }
    }
}