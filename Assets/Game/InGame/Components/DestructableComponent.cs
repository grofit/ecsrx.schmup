using System;
using EcsRx.Components;
using UniRx;

namespace Game.InGame.Components
{
    public class DestructableComponent : IComponent, IDisposable
    {
        public ReactiveProperty<int> Health { get; set; }
        public float Size { get; set; }

        public DestructableComponent()
        {
            Health = new IntReactiveProperty();
        }

        public void Dispose()
        {
            Health.Dispose();
        }
    }
}