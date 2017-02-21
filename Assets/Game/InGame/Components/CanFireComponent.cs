using EcsRx.Components;

namespace Assets.Game.InGame.Components
{
    public class CanFireComponent : IComponent
    {
        public float LastFired { get; set; }
        public float FireRate { get; set; }
        public bool IsFiring { get; set; }
    }
}