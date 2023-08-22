using Kaynir.TDSTest.Agents;
using Kaynir.TDSTest.Movement;
using Kaynir.TDSTest.Tools.Extensions;
using UnityEngine;

namespace Kaynir.TDSTest.AI.States
{
    public class AIGuardState : IState
    {
        private AgentMovement movement;

        private Transform origin;
        private Transform lookPoint;

        public AIGuardState(Agent agent, Transform lookPoint)
        {
            this.lookPoint = lookPoint;

            movement = agent.Movement;
            origin = movement.transform;
        }

        public void OnEnter() { }
        public void OnExit() { }

        public void Tick()
        {
            if (!lookPoint) return;

            Vector2 direction = origin.DirectionToNormalized(lookPoint);
            movement.SetLookDirection(direction);
        }

        public Color GetGizmosColor()
        {
            return Color.blue;
        }
    }
}