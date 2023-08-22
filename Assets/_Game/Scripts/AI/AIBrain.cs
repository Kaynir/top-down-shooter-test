using Kaynir.TDSTest.Agents;
using Kaynir.TDSTest.AI.States;
using Kaynir.TDSTest.Detection;
using UnityEngine;

namespace Kaynir.TDSTest.AI
{
    [RequireComponent(typeof(Agent))]
    [RequireComponent (typeof(Detector))]
    public class AIBrain : MonoBehaviour
    {
        [Header("Guard Settings:")]
        [SerializeField] private Transform guardPoint = null;

        [Header("Gizmos Settings:")]
        [SerializeField] private bool drawGizmos = true;
        [SerializeField] private Transform stateGizmosPoint = null;
        [SerializeField] private float stateGizmosRadius = .2f;

        private Agent agent;
        private Detector detector;
        private StateMachine stateMachine;
    
        private void Awake()
        {
            agent = GetComponent<Agent>();
            detector = GetComponent<Detector>();
        }

        private void Start()
        {
            stateMachine = new StateMachine();

            AIGuardState guardState = new AIGuardState(agent, guardPoint);
            AIAttackState attackState = new AIAttackState(agent, detector);

            stateMachine.AddAnyTransition(guardState, () => !detector.HasTarget);
            stateMachine.AddTransition(guardState, attackState, () => detector.HasTarget);
        }

        private void Update()
        {
            stateMachine.Tick();
        }

        private void OnDrawGizmos()
        {
            if (!drawGizmos) return;
            if (stateMachine == null) return;

            Gizmos.color = stateMachine.GetGizmosColor();
            Gizmos.DrawSphere(stateGizmosPoint.position, stateGizmosRadius);
        }
    }
}