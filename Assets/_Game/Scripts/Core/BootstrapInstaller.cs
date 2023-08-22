using UnityEngine;
using Zenject;

namespace Kaynir.TDSTest.Core
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private GameOverHandler gameOverHandler = null;

        public override void InstallBindings()
        {
            BindGameOverHandler();
        }

        private void BindGameOverHandler()
        {
            Container.Bind<GameOverHandler>()
                     .FromInstance(gameOverHandler)
                     .AsSingle();
        }
    }
}
