﻿using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Pools;
using EcsRx.Systems;
using Game.InGame.Blueprint;
using Game.InGame.Components;
using Game.InGame.Configurations;
using UniRx;

namespace Game.InGame.Systems
{
    public class DestructableDestroyedSystem : IReactToEntitySystem
    {
        public IGroup TargetGroup { get { return new Group(typeof(DestructableComponent));} }
        private readonly IPool _destructablePool;
        private readonly IPool _explosionPool;

        public DestructableDestroyedSystem(IPoolManager poolManager)
        {
            _destructablePool = poolManager.GetPool(PoolConfigurations.DestructablesPool);
            _explosionPool = poolManager.GetPool(PoolConfigurations.ExplosionsPool);
        }

        public IObservable<IEntity> ReactToEntity(IEntity entity)
        {
            var destructableComponent = entity.GetComponent<DestructableComponent>();
            return destructableComponent.Health.Single(x => x <= 0).Select(x => entity);
        }

        public void Execute(IEntity entity)
        {
            var destructableComponent = entity.GetComponent<DestructableComponent>();
            var destructionSize = destructableComponent.Size;
            _destructablePool.RemoveEntity(entity);
            _explosionPool.CreateEntity(new ExplosionBlueprint(destructionSize));
        }
    }
}