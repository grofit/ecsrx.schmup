﻿using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Systems;
using Game.InGame.Components;
using Game.InGame.Configurations;
using UniRx;
using UnityEngine;

namespace Game.InGame.Systems
{
    public class StandardInputSystem : IReactToGroupSystem
    {
        public IGroup TargetGroup { get { return new Group(typeof(StandardInputComponent), typeof(CanFireComponent), typeof(MovementComponent)); } }
        
        public IObservable<IGroupAccessor> ReactToGroup(IGroupAccessor @group)
        { return Observable.EveryUpdate().Select(x => @group); }

        public void Execute(IEntity entity)
        {
            var movement = new Vector3();
            movement.x = Input.GetAxis(InputConfiguration.HorizontalAxis);
            movement.y = Input.GetAxis(InputConfiguration.VerticalAxis);

            var movementComponent = entity.GetComponent<MovementComponent>();
            movementComponent.NextMovement = movement;

            var canFireComponent = entity.GetComponent<CanFireComponent>();
            canFireComponent.IsFiring = Input.GetButton(InputConfiguration.FireButton);
        }
    }
}