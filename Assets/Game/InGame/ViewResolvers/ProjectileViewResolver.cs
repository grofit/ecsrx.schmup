using Assets.Game.InGame.Components;
using EcsRx.Entities;
using EcsRx.Events;
using EcsRx.Groups;
using EcsRx.Pools;
using EcsRx.Unity.Components;
using EcsRx.Unity.Systems;
using UnityEngine;
using Zenject;

namespace Assets.Game.InGame.ViewResolvers
{
    public class ProjectileViewResolver : DefaultPooledViewResolverSystem
    {
        public override IGroup TargetGroup
        {
            get { return new Group(typeof(ProjectileComponent), typeof(ViewComponent)); }
        }

        public ProjectileViewResolver(IPoolManager poolManager, IEventSystem eventSystem, IInstantiator instantiator)
            : base(poolManager, eventSystem, instantiator)
        {
            ViewPool.PreAllocate(50);
        }

        protected override GameObject ResolvePrefabTemplate()
        { return Resources.Load<GameObject>("Prefabs/Bullet"); }

        protected override GameObject AllocateView(IEntity entity, IPool pool)
        {
            var projectileComponent = entity.GetComponent<ProjectileComponent>();

            var allocatedView = base.AllocateView(entity, pool);
            allocatedView.name = string.Format("projectile-{0}", entity.Id);
            allocatedView.transform.position = projectileComponent.StartingPosition;
            return allocatedView;
        }
    }
}