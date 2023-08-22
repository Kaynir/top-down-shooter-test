using System;
using Kaynir.TDSTest.Agents.Actions;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Kaynir.TDSTest.Player
{
    public class PlayerControls : MonoBehaviour
    {
        public event Action<Vector2> MovePerformed;
        public event Action<Vector2> LookPerformed;
        public event Action<ActionType> ActionPerformed;

        [SerializeField] private Camera mainCamera = null;

        #region Input System Callbacks
        public void OnMovePerformed(CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            MovePerformed?.Invoke(input);
        }

        public void OnLookPerformed(CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            input = mainCamera.ScreenToWorldPoint(input);

            LookPerformed?.Invoke(input);
        }

        public void OnCrouchPerformed(CallbackContext context)
        {
            ActionPerformed?.Invoke(ActionType.Crouch);
        }
        #endregion
    }
}