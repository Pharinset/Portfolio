using Leopotam.Ecs;
using OOP.StoveScene;
using Stove.Components;
using Stove.ScriptableObjects;
using UnityEngine;

namespace Stove.Systems
{
    public class CircleTargetInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private StoveInitData _initData;
        
        public void Init()
        {
            var switchGameObject = Object.Instantiate(_initData.TemperatureSwitchObj);
            var switchRotator = switchGameObject.GetComponent<Rotator>();

            var entity = _world.NewEntity();
            ref var rotatorComponent = ref entity.Get<RotatorComponent>();
            rotatorComponent.Rotator = switchRotator.GetRotateObj();
            rotatorComponent.Speed = 50f;

            ref var circleTargetComponent = ref entity.Get<CircleTargetComponent>();
            circleTargetComponent.Collider = switchRotator.GetComponent<CircleCollider2D>();
        }
    }
}
