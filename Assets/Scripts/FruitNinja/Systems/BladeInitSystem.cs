using FruitNinja.Components;
using FruitNinja.ScriptableObjects;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace FruitNinja.Systems
{
    public class BladeInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private BladeInitData _bladeInitData;
    
        public void Init()
        {
            var blade = _world.NewEntity();
            var spawnedBlade = Object.Instantiate(_bladeInitData.BladePrefab);
            spawnedBlade.transform.position += new Vector3(-10, -10, 0);
            
            ref var bladeComponent = ref blade.Get<BladeComponent>();
            bladeComponent.Rigidbody = spawnedBlade.GetComponent<Rigidbody2D>();
            bladeComponent.Collider = spawnedBlade.GetComponent<CircleCollider2D>();
            bladeComponent.Transform = spawnedBlade.transform;
        }
    }
}
