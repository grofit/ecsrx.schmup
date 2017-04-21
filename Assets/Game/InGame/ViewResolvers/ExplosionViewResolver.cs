using EcsRx.Entities;
using EcsRx.Events;
using EcsRx.Groups;
using EcsRx.Pools;
using EcsRx.Unity.Components;
using EcsRx.Unity.Systems;
using Game.InGame.Components;
using UnityEngine;
using Zenject;

namespace Game.InGame.ViewResolvers
{
    public class ExplosionViewResolver : DefaultPooledViewResolverSystem
    {
        public override IGroup TargetGroup
        {
            get { return new Group(typeof(ExplosionComponent), typeof(ViewComponent)); }
        }

        public ExplosionViewResolver(IPoolManager poolManager, IEventSystem eventSystem, IInstantiator instantiator)
            : base(poolManager, eventSystem, instantiator)
        {
            ViewPool.PreAllocate(30);
        }

        protected override GameObject ResolvePrefabTemplate()
        { return Resources.Load<GameObject>("Prefabs/Explosion"); }

        protected override GameObject AllocateView(IEntity entity, IPool pool)
        {
            var allocatedView = base.AllocateView(entity, pool);
            allocatedView.name = string.Format("explosion-{0}", entity.Id);
            return allocatedView;
        }
    }
}