using EcsRx.Pools;
using Game.InGame.Configurations;
using Zenject;

namespace Game.InGame.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var poolManager = Container.Resolve<IPoolManager>();

            poolManager.CreatePool(PoolConfigurations.DefaultPool);
            poolManager.CreatePool(PoolConfigurations.ProjectilesPool);
            poolManager.CreatePool(PoolConfigurations.ExplosionsPool);
            poolManager.CreatePool(PoolConfigurations.DestructablesPool);
        }
    }
}