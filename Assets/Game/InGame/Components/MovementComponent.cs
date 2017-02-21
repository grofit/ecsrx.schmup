using System;
using EcsRx.Components;
using UniRx;
using UnityEngine;

namespace Assets.Game.InGame.Components
{
    public class MovementComponent : IComponent
    {
        public float MovementSpeed { get; set; }
        public Vector3 NextMovement { get; set; }
    }
}