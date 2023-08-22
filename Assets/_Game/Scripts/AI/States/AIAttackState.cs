using Kaynir.TDSTest.Agents;
using Kaynir.TDSTest.Detection;
using Kaynir.TDSTest.Movement;
using Kaynir.TDSTest.Weapons;
using UnityEngine;

namespace Kaynir.TDSTest.AI.States
{
    public class AIAttackState : IState
    {
        private Detector detector;
        private AgentMovement movement;
        private Weapon weapon;

        public AIAttackState(Agent agent, Detector detector)
        {
            this.detector = detector;
            
            movement = agent.Movement;
            weapon = agent.Weapon;
        }

        public void OnEnter() { }

        public void OnExit() { }

        public void Tick()
        {
            Vector2 targetPosition = detector.Target.Agent.Movement.Position;
            Vector2 direction = (targetPosition - movement.Position).normalized;

            movement.SetLookDirection(direction);
            weapon.TryAttack();
        }

        public Color GetGizmosColor()
        {
            return Color.red;
        }
    }
}