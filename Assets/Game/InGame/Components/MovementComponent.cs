using EcsRx.Components;
using UnityEngine;

namespace Game.InGame.Components
{
    public class MovementComponent : IComponent
    {
        public float MovementSpeed { get; set; }
        public Vector3 NextMovement { get; set; }
    }
}