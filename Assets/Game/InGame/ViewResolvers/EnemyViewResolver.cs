﻿using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Unity.Components;
using EcsRx.Unity.Systems;
using Game.InGame.Components;
using UnityEngine;

namespace Game.InGame.ViewResolvers
{
    public class EnemyViewResolver : ViewResolverSystem
    {
        private readonly GameObject _prefabTemplate;

        public override IGroup TargetGroup
        {
            get { return new Group(typeof(EnemyComponent), typeof(ViewComponent)); }
        }

        public EnemyViewResolver(IViewHandler viewHandler) : base(viewHandler)
        {
            _prefabTemplate = Resources.Load<GameObject>("Prefabs/EnemyShip");
        }

        public override GameObject ResolveView(IEntity entity)
        {
            var enemyGo = Object.Instantiate(_prefabTemplate);
            enemyGo.transform.position = new Vector3(10.0f, 0, 0);
            return enemyGo;
        }
    }
}