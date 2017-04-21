using EcsRx.Unity;
using Game.InGame.Blueprint;
using Game.InGame.Configurations;

namespace Game.InGame
{
    public class InGameApplication : EcsRxApplication
    {
        protected override void ApplicationStarting()
        {
            RegisterAllBoundSystems();
        }

        protected override void ApplicationStarted()
        {
            var destructablePool = PoolManager.GetPool(PoolConfigurations.DestructablesPool);

            destructablePool.CreateEntity(new PlayerBlueprint());

            destructablePool.CreateEntity(new EnemyBlueprint());
        }
    }
}