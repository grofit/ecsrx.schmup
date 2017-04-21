using EcsRx.Components;
using UnityEngine;

namespace Game.InGame.Components
{
    public class ProjectileComponent : IComponent
    {
        public Vector3 StartingPosition { get; set; }
        public Vector3 Direction { get; set; }
        public float Lifetime { get; set; }
        public float ElapsedTime { get; set; }
        public int Damage { get; set; }
    }
}