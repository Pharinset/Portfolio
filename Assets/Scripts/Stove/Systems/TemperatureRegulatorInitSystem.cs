using Leopotam.Ecs;
using Stove.ScriptableObjects;
using UnityEngine;

namespace Stove.Systems
{
    public class TemperatureRegulatorInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private StoveInitData _initData;
        
        public void Init()
        {
            var switchGameObject = Object.Instantiate(_initData.TemperatureObj);
        }
    }
}
