using UnityEngine;

namespace Kaynir.TDSTest.Agents.Actions
{
    public abstract class AgentAction : MonoBehaviour
    {
        public abstract void Execute(Agent agent);
    }
}