using Kaynir.TDSTest.Agents;
using Kaynir.TDSTest.Agents.Actions;
using UnityEngine;

namespace Kaynir.TDSTest.Detection
{
    [RequireComponent(typeof(Agent))]
    public class DetectableAgent : MonoBehaviour, IDetectable
    {
        [SerializeField] private CrouchAction crouchAction = null;

        public Agent Agent { get; private set; }
        public bool InStealth => crouchAction && crouchAction.InStealth;
        
        private void Awake()
        {
            Agent = GetComponent<Agent>();
        }
    }
}