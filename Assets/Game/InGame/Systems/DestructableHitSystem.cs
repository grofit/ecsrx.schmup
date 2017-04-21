using EcsRx.Events;
using EcsRx.Systems.Custom;
using Game.InGame.Components;
using Game.InGame.Events;

namespace Game.InGame.Systems
{
    public class DestructableHitSystem : EventReactionSystem<DestructableHitEvent>
    {
        public DestructableHitSystem(IEventSystem eventSystem) : base(eventSystem)
        {}

        public override void EventTriggered(DestructableHitEvent eventData)
        {
            var destructable = eventData.Destructable.GetComponent<DestructableComponent>();
            var projectile = eventData.Projectile.GetComponent<ProjectileComponent>();
            destructable.Health.Value -= projectile.Damage;
        }
    }
}