using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Systems;
using EcsRx.Unity.Components;
using Game.InGame.Components;
using UniRx;
using UnityEngine;

namespace Game.InGame.Systems
{
    public class MovementSystem : IReactToGroupSystem
    {
        public IGroup TargetGroup { get { return new Group(typeof(MovementComponent), typeof(ViewComponent)); } }
 
        public IObservable<IGroupAccessor> ReactToGroup(IGroupAccessor @group)
        { return Observable.EveryUpdate().Select(x => @group); }

        public void Execute(IEntity entity)
        {
            var actionComponent = entity.GetComponent<MovementComponent>();
            if(actionComponent.NextMovement == Vector3.zero) { return; }

            var viewComponent = entity.GetComponent<ViewComponent>();

            var movementDelta = actionComponent.NextMovement * actionComponent.MovementSpeed * Time.deltaTime;
            var newPosition = viewComponent.View.transform.position + movementDelta;
            var translatedPosition = Camera.main.WorldToScreenPoint(newPosition);

            if (translatedPosition.x < 0)
            { newPosition.x = 0; }
            else if(translatedPosition.x > Screen.width)
            { newPosition.x = Screen.width; }

            if(translatedPosition.y < 0)
            { newPosition.y = 0; }
            else if(translatedPosition.y > Screen.height)
            { newPosition.y = Screen.height; }

            viewComponent.View.transform.position = newPosition;
        }
    }
}