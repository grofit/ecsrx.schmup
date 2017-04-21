using EcsRx.Components;
using UnityEngine;

namespace Game.InGame.Components
{
    public class ExplosionComponent : IComponent
    {
        public Vector3 Position { get; set; }
        public float Size { get; set; }
    }
}