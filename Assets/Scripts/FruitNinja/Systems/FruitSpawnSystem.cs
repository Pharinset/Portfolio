using System;
using FruitNinja.Components;
using Leopotam.Ecs;
using FruitNinja.ScriptableObjects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace FruitNinja.Systems
{
    sealed class FruitSpawnSystem : IEcsRunSystem
    {
        private const float SpawnDelay = 3;
        readonly EcsWorld _world = null;
        private FruitInitData _fruitInitData;

        private DateTime _lastSpawn = DateTime.MinValue;

        public void Run()
        {
            if (DateTime.Now.Subtract(_lastSpawn).TotalSeconds > SpawnDelay)
                Spawn();
        }

        private void Spawn()
        {
            _lastSpawn = DateTime.Now;
            
            var fruit = _world.NewEntity();
            var spawnedFruit = Object.Instantiate(_fruitInitData.FruitPrefab);
            spawnedFruit.transform.position += new Vector3(0, -2, 0);
            
            ref var fruitMovementComponent = ref fruit.Get<FruitComponent>();
            fruitMovementComponent.Rigidbody = spawnedFruit.GetComponent<Rigidbody2D>();
            fruitMovementComponent.Collider = spawnedFruit.GetComponent<CircleCollider2D>();
            fruitMovementComponent.SpriteRenderer = spawnedFruit.GetComponent<SpriteRenderer>();
        }
    }
}