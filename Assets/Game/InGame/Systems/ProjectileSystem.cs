using Assets.Game.InGame.Components;
using Assets.Game.InGame.Configurations;
using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Pools;
using EcsRx.Systems;
using EcsRx.Unity.Components;
using UniRx;
using UnityEngine;

namespace Assets.Game.InGame.Systems
{
    public class ProjectileSystem : IReactToGroupSystem
    {
        public IGroup TargetGroup { get { return new Group(typeof(ProjectileComponent), typeof(ViewComponent)); } }
        private IPool _projectilePool { get; set; }

        public ProjectileSystem(IPoolManager poolManager)
        { _projectilePool = poolManager.GetPool(PoolConfigurations.ProjectilesPool); }

        public IObservable<IGroupAccessor> ReactToGroup(IGroupAccessor @group)
        { return Observable.EveryUpdate().Select(x => @group); }

        public void Execute(IEntity entity)
        {
            var viewComponent = entity.GetComponent<ViewComponent>();
            var projectileComponent = entity.GetComponent<ProjectileComponent>();

            var newPosition = projectileComponent.Direction * Time.deltaTime;
            viewComponent.View.transform.position += newPosition;
            projectileComponent.ElapsedTime += Time.deltaTime;

            if (projectileComponent.ElapsedTime >= projectileComponent.Lifetime)
            { _projectilePool.RemoveEntity(entity); }
        }
    }
}