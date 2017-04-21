using EcsRx.Components;
using UnityEngine;

namespace Game.InGame.Components
{
    public class CanFireComponent : IComponent
    {
        public float LastFired { get; set; }
        public float FireRate { get; set; }
        public Vector3 Direction { get; set; }
        public bool IsFiring { get; set; }
    }
}