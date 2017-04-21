using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Systems;
using Game.InGame.Components;
using UniRx;
using UnityEngine;

namespace Game.InGame.Systems
{
    public class AiInputSystem : IReactToGroupSystem
    {
        public IGroup TargetGroup { get { return new Group(typeof(AIInputComponent), typeof(CanFireComponent), typeof(MovementComponent)); } }
        
        public IObservable<IGroupAccessor> ReactToGroup(IGroupAccessor @group)
        { return Observable.EveryUpdate().Select(x => @group); }

        public void Execute(IEntity entity)
        {
            var movement = new Vector3 { x = 1.0f };

            var movementComponent = entity.GetComponent<MovementComponent>();
            movementComponent.NextMovement = movement;

            var canFireComponent = entity.GetComponent<CanFireComponent>();
            canFireComponent.IsFiring = true;
        }
    }
}