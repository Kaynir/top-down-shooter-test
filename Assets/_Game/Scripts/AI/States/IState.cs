using UnityEngine;

namespace Kaynir.TDSTest.AI.States
{
    public interface IState
    {
        void OnEnter();
        void Tick();
        void OnExit();
        Color GetGizmosColor();
    }
}