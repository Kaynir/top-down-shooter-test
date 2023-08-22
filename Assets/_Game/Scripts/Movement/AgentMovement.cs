using UnityEngine;

namespace Kaynir.TDSTest.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AgentMovement : MonoBehaviour
    {
        [Header("Move Settings:")]
        [SerializeField] private float moveSpeed = 10f;

        [Header("Rotation Settings:")]
        [SerializeField] private float turnSpeed = 5f;
        [SerializeField, Range(0, 180f)] private float angleOffset = 90f;

        public float MoveSpeed => currentSpeed;
        public Vector2 Position => body.position;

        private Rigidbody2D body;

        private Vector2 moveDirection;
        private float currentSpeed;
        private float lookAngle;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            body.MovePosition(GetMovePosition());
            body.SetRotation(GetLookRotation());
        }

        public void SetMoveDirection(Vector2 direction)
        {
            moveDirection = direction;
        }

        public void SetLookDirection(Vector2 direction)
        {
            lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            lookAngle -= angleOffset;
        }

        public void ModifyMoveSpeed(float amount)
        {
            currentSpeed += amount;
        }

        public void ResetMoveSpeed()
        {
            currentSpeed = moveSpeed;
        }

        private Vector2 GetMovePosition()
        {
            Vector2 position = body.position;
            position += moveDirection * currentSpeed * Time.fixedDeltaTime;
            return position;
        }

        private float GetLookRotation()
        {
            return Mathf.MoveTowardsAngle(body.rotation,
                                          lookAngle,
                                          turnSpeed);
        }
    }
}