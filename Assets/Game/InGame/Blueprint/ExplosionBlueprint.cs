using EcsRx.Blueprints;
using EcsRx.Entities;
using Game.InGame.Components;

namespace Game.InGame.Blueprint
{
    public class ExplosionBlueprint : IBlueprint
    {
        private readonly float _size;

        public ExplosionBlueprint(float size)
        {
            _size = size;
        }

        public void Apply(IEntity entity)
        {
            var explosionComponent = new ExplosionComponent { Size = _size };
            entity.AddComponent(explosionComponent);
        }
    }
}