using FruitNinja.Components;
using FruitNinja.ScriptableObjects;
using Leopotam.Ecs;
using UnityEngine;

namespace FruitNinja.Systems
{
    public class FruitSeparatorSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;

        private FruitInitData _fruitInitData;
        private EcsFilter<FruitComponent> _fruits = null;
        private EcsFilter<FruitCannonComponent> _fruitsParticles = null;
        public void Run()
        {
            foreach (var fruit in _fruits)
            {
                ref var fruitComponent = ref _fruits.Get1(fruit);

                if (fruitComponent.IsCut)
                {
                    var posDestroy = DestroyObject(fruitComponent, _fruits.GetEntity(fruit));
                    SpawnParticles(posDestroy);
                    continue;
                }

                if (fruitComponent.SpriteRenderer.gameObject.transform.position.y < -5)
                {
                    DestroyObject(fruitComponent, _fruits.GetEntity(fruit));
                }
            }
            
            foreach (var fruit in _fruitsParticles)
            {
                ref var fruitComponent = ref _fruitsParticles.Get1(fruit);

                if (fruitComponent.GameObject.transform.position.y < -4)
                {
                    Object.Destroy(fruitComponent.GameObject);
                    _fruitsParticles.GetEntity(fruit).Destroy();
                }
            }
        }

        private Vector3 DestroyObject(FruitComponent fruitComponent, EcsEntity entity)
        {
            var pos = fruitComponent.Collider.gameObject.transform.position;
            Object.Destroy(fruitComponent.Collider.gameObject);
            entity.Destroy();
            return pos;
        }

        private void SpawnParticles(Vector3 pos)
        {
            var particleHalfOne = Object.Instantiate(_fruitInitData.FruitHalfPrefab);
            var particleHalfSecond = Object.Instantiate(_fruitInitData.FruitHalfPrefab);
            particleHalfOne.transform.position = pos;
            particleHalfSecond.transform.position = pos;
            particleHalfOne.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            particleHalfOne.GetComponent<Rigidbody2D>().AddForce(Vector2.right);
            particleHalfSecond.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            particleHalfSecond.GetComponent<Rigidbody2D>().AddForce(Vector2.left);

            var entityParticleOne = _world.NewEntity();
            ref var fruitHalfParticleOne = ref entityParticleOne.Get<FruitCannonComponent>();
            fruitHalfParticleOne.GameObject = particleHalfOne;
            var entityParticleTwo = _world.NewEntity();
            ref var fruitHalfParticleTwo = ref entityParticleTwo.Get<FruitCannonComponent>();
            fruitHalfParticleTwo.GameObject = particleHalfSecond;
        }
    }
}
