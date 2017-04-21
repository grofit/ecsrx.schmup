using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Unity.Components;
using EcsRx.Unity.Systems;
using Game.InGame.Components;
using UnityEngine;

namespace Game.InGame.ViewResolvers
{
    public class PlayerViewResolver : ViewResolverSystem
    {
        private readonly GameObject _prefabTemplate;

        public override IGroup TargetGroup
        {
            get { return new Group(typeof(PlayerComponent), typeof(ViewComponent)); }
        }

        public PlayerViewResolver(IViewHandler viewHandler) : base(viewHandler)
        {
            _prefabTemplate = Resources.Load<GameObject>("Prefabs/PlayerShip");
        }

        public override GameObject ResolveView(IEntity entity)
        { return Object.Instantiate(_prefabTemplate); }
    }
}