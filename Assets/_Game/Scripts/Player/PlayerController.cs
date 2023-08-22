using Cinemachine;
using Kaynir.TDSTest.Agents;
using Kaynir.TDSTest.Agents.Actions;
using Kaynir.TDSTest.Core;
using UnityEngine;
using Zenject;

namespace Kaynir.TDSTest.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerControls controls = null;
        [SerializeField] private CinemachineVirtualCamera virtualCamera = null;

        private Agent agent;
        private GameOverHandler gameOverHandler;

        [Inject]
        public void Construct(Agent agent, GameOverHandler gameOverHandler)
        {
            this.agent = agent;
            this.gameOverHandler = gameOverHandler;

            virtualCamera.Follow = agent.transform;
            virtualCamera.LookAt = agent.transform;
        }

        private void OnEnable()
        {
            controls.MovePerformed += OnMovePerformed;
            controls.LookPerformed += OnLookPerformed;
            controls.ActionPerformed += OnActionPerformed;
            agent.Health.ValueDepleted += OnAgentDied;
        }

        private void OnDisable()
        {
            controls.MovePerformed -= OnMovePerformed;
            controls.LookPerformed -= OnLookPerformed;
            controls.ActionPerformed -= OnActionPerformed;
            agent.Health.ValueDepleted -= OnAgentDied;
        }

        private void OnMovePerformed(Vector2 input)
        {
            agent.Movement.SetMoveDirection(input);
        }

        private void OnLookPerformed(Vector2 input)
        {
            Vector2 direction = input - agent.Movement.Position;
            agent.Movement.SetLookDirection(direction.normalized);
        }

        private void OnActionPerformed(ActionType actionType)
        {
            agent.Actions.TryPerformAction(actionType, agent);
        }

        private void OnAgentDied()
        {
            agent.gameObject.SetActive(false);
            enabled = false;

            Debug.Log("Player died!");
            gameOverHandler.EndGame();
        }
    }
}