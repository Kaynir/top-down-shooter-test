using Kaynir.TDSTest.Agents;
using UnityEngine;
using Zenject;

namespace Kaynir.TDSTest.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Agent agentPrefab = null;
        [SerializeField] private Transform agentParent = null;

        public override void InstallBindings()
        {
            BindAgent();
        }

        private void BindAgent()
        {
            Container.Bind<Agent>()
                     .FromComponentInNewPrefab(agentPrefab)
                     .UnderTransform(agentParent)
                     .AsSingle();
        }
    }
}