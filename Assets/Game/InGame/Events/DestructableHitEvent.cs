using EcsRx.Entities;

namespace Assets.Game.InGame.Events
{
    public class DestructableHitEvent
    {
        public IEntity Projectile { get; private set; } 
        public IEntity Destructable { get; private set; }

        public DestructableHitEvent(IEntity projectile, IEntity destructable)
        {
            Projectile = projectile;
            Destructable = destructable;
        }
    }
}