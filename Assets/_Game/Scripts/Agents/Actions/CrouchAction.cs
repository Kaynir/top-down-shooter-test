using System;
using Kaynir.TDSTest.Movement;
using Kaynir.TDSTest.Tools;
using UnityEngine;

namespace Kaynir.TDSTest.Agents.Actions
{
    public class CrouchAction : AgentAction
    {
        [SerializeField, Range(0f, 1f)] private float moveSpeedPenalty = .5f;

        public bool InStealth { get; private set; }

        public override void Execute(Agent agent)
        {
            agent.Animator.SetBool(AnimationConsts.STEALTH_HASH, !InStealth);
            
            if (InStealth) DisableCrouch(agent.Movement);
            else EnableCrouch(agent.Movement);
        }

        private void EnableCrouch(AgentMovement movement)
        {
            InStealth = true;
            movement.ModifyMoveSpeed(GetSpeedModifier(movement));
        }

        private void DisableCrouch(AgentMovement movement)
        {
            InStealth = false;
            movement.ResetMoveSpeed();
        }

        private float GetSpeedModifier(AgentMovement movement)
        {
            return -movement.MoveSpeed * moveSpeedPenalty;
        }
    }
}