using EcsRx.Blueprints;
using EcsRx.Entities;
using EcsRx.Unity.Components;
using Game.InGame.Components;
using UnityEngine;

namespace Game.InGame.Blueprint
{
    public class ProjectileBlueprint : IBlueprint
    {
        private readonly Vector3 _startingPosition;
        private readonly float _lifetime;
        private readonly int _damage;

        public ProjectileBlueprint(Vector3 startingPosition, int damage = 1, float lifetime = 3.0f)
        {
            _startingPosition = startingPosition;
            _damage = damage;
            _lifetime = lifetime;
        }

        public void Apply(IEntity entity)
        {
            var projectileComponent = new ProjectileComponent
            {
                Damage = _damage,
                StartingPosition = _startingPosition,
                Lifetime = _lifetime,
                Direction = Vector3.right * 10
            };
            entity.AddComponent(projectileComponent);
            entity.AddComponent<ViewComponent>();
        }
    }
}