using Leopotam.Ecs;
using Stove.Components;
using Stove.ScriptableObjects;
using UnityEngine;

namespace Stove.Systems
{
    public class StoveInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private StoveInitData _initData;
        
        public void Init()
        {
            var switchGameObject = Object.Instantiate(_initData.StoveObj);
            var stoveComponent = switchGameObject.GetComponent<OOP.StoveScene.Stove>();

            var entity = _world.NewEntity();
            ref var stoveC = ref entity.Get<StoveComponent>();
            stoveC.Stove = stoveComponent;
        }
    }
}
