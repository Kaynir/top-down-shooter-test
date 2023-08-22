using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kaynir.TDSTest.Agents.Actions
{
    public class ActionHandler : MonoBehaviour
    {
        [SerializeField] private List<ActionInfo> availableActions = new List<ActionInfo>();

        private Dictionary<ActionType, AgentAction> actions;

        private void Awake()
        {
            actions = availableActions.ToDictionary(a => a.type, a => a.action);
        }

        public bool TryPerformAction(ActionType actionType, Agent agent)
        {
            if (!actions.TryGetValue(actionType, out AgentAction action))
            {
                return false;
            }

            action.Execute(agent);
            return true;
        }

        [Serializable]
        private struct ActionInfo
        {
            public ActionType type;
            public AgentAction action;
        }
    }
}