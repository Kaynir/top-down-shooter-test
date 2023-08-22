using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kaynir.TDSTest.AI.States
{
    public class StateMachine
    {
        private IState activeState;

        private Dictionary<Type, List<Transition>> transitions;
        
        private List<Transition> activeTransitions;
        private List<Transition> anyTransitions;
        
        private static readonly List<Transition> defaultTransitions = new List<Transition>(0);

        public StateMachine()
        {
            transitions = new Dictionary<Type, List<Transition>>();
            
            activeTransitions = new List<Transition>();
            anyTransitions = new List<Transition>();
        }

        public void SetState(IState state)
        {
            if (state == activeState) return;

            activeState?.OnExit();
            activeState = state;
            activeState.OnEnter();

            if (!transitions.TryGetValue(activeState.GetType(), out activeTransitions))
            {
                activeTransitions = defaultTransitions;
            }
        }

        public void Tick()
        {
            Transition transition = GetTransition();
            
            if (transition) SetState(transition.toState);
            
            activeState?.Tick();
        }

        public void AddTransition(IState fromState, IState toState, Func<bool> condition)
        {
            Type fromStateType = fromState.GetType();

            if (!transitions.TryGetValue(fromStateType, out var transitionList))
            {
                transitionList = new List<Transition>();
                transitions[fromStateType] = transitionList;
            }

            transitionList.Add(new Transition(toState, condition));
        }

        public void AddAnyTransition(IState state, Func<bool> condition)
        {
            anyTransitions.Add(new Transition(state, condition));
        }

        public Color GetGizmosColor()
        {
            if (activeState == null) return Color.gray;
            return activeState.GetGizmosColor();
        }

        private Transition GetTransition()
        {
            foreach (var transition in anyTransitions)
            {
                if (transition.condition()) return transition;
            }

            foreach (var transition in activeTransitions)
            {
                if (transition.condition()) return transition;
            }

            return new Transition();
        }
    }
}