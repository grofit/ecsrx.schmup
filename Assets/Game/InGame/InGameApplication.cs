using Assets.Game.InGame.Blueprint;
using Assets.Game.InGame.Configurations;
using EcsRx.Unity;

namespace Assets.Game.InGame
{
    public class InGameApplication : EcsRxApplication
    {
        protected override void ApplicationStarted()
        {
            var destructablePool = PoolManager.GetPool(PoolConfigurations.DestructablesPool);

            destructablePool.CreateEntity(new PlayerBlueprint());
        }
    }
}