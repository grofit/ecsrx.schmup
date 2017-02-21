using Assets.Game.InGame.Components;
using Assets.Game.InGame.Events;
using EcsRx.Events;
using EcsRx.Systems.Custom;

namespace Assets.Game.InGame.Systems
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