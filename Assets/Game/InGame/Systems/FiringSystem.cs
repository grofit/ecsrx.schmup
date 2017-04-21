using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Pools;
using EcsRx.Systems;
using EcsRx.Unity.Components;
using Game.InGame.Blueprint;
using Game.InGame.Components;
using Game.InGame.Configurations;
using UniRx;
using UnityEngine;

namespace Game.InGame.Systems
{
    public class FiringSystem : IReactToGroupSystem
    {
        public IGroup TargetGroup { get { return new Group(typeof(CanFireComponent), typeof(ViewComponent)); } }
        private readonly IPool _projectilePool;

        public FiringSystem(IPoolManager poolManager)
        {
            _projectilePool = poolManager.GetPool(PoolConfigurations.ProjectilesPool);
        }

        public IObservable<IGroupAccessor> ReactToGroup(IGroupAccessor @group)
        { return Observable.EveryUpdate().Select(x => @group); }

        public void Execute(IEntity entity)
        {
            var actionComponent = entity.GetComponent<CanFireComponent>();
            actionComponent.LastFired += Time.deltaTime;

            if(!actionComponent.IsFiring) { return; }

            var canFire = actionComponent.LastFired >= actionComponent.FireRate;
            if(!canFire) { return; }

            actionComponent.LastFired = 0;

            var viewComponent = entity.GetComponent<ViewComponent>();
            var startingPosition = viewComponent.View.transform.position + actionComponent.Direction;
            _projectilePool.CreateEntity(new ProjectileBlueprint(startingPosition));
        }
    }
}