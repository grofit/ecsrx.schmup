using Assets.Game.InGame.Components;
using EcsRx.Blueprints;
using EcsRx.Entities;
using EcsRx.Unity.Components;

namespace Assets.Game.InGame.Blueprint
{
    public class PlayerBlueprint : IBlueprint
    {
        public void Apply(IEntity entity)
        {
            var destructableComponent = new DestructableComponent();
            destructableComponent.Health.Value = 100;

            entity.AddComponent(destructableComponent);

            var actionComponent = new MovementComponent {MovementSpeed = 3.0f};
            entity.AddComponent(actionComponent);

            var canFireComponent = new CanFireComponent { FireRate = 0.1f };
            entity.AddComponent(canFireComponent);

            entity.AddComponent<PlayerComponent>();
            entity.AddComponent<StandardInputComponent>();
            entity.AddComponent<ViewComponent>();
        }
    }
}