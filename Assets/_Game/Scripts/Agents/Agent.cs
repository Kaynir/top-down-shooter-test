using Kaynir.TDSTest.Agents.Actions;
using Kaynir.TDSTest.Damageables;
using Kaynir.TDSTest.Movement;
using Kaynir.TDSTest.Weapons;
using UnityEngine;

namespace Kaynir.TDSTest.Agents
{
    public class Agent : MonoBehaviour
    {
        [SerializeField] private HealthSystem health = null;
        [SerializeField] private AgentMovement movement = null;
        [SerializeField] private ActionHandler actions = null;
        [SerializeField] private Animator animator = null;
        [SerializeField] private Weapon weapon = null;

        public HealthSystem Health => health;
        public AgentMovement Movement => movement;
        public ActionHandler Actions => actions;
        public Animator Animator => animator;
        public Weapon Weapon => weapon;

        private void Start()
        {
            Health.ResetValue();
            Movement.ResetMoveSpeed();
        }
    }
}