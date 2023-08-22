using System;

namespace Kaynir.TDSTest.AI.States
{
    public struct Transition
    {
        public IState toState;
        public Func<bool> condition;

        public Transition(IState toState, Func<bool> condition)
        {
            this.toState = toState;
            this.condition = condition;
        }

        public static implicit operator bool(Transition transition)
        {
            return transition.toState != null;
        }
    }
}