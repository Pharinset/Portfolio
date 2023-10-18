using FruitNinja.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace FruitNinja.Systems
{
    public class FruitMovementSystem : IEcsRunSystem
    {
        private EcsFilter<FruitComponent> _filter = null;

        public void Run()
        {
            foreach (var fruit in _filter)
            {
                ref var fruitComponent = ref _filter.Get1(fruit);
            
                if(fruitComponent.IsDrop)
                    continue;

                fruitComponent.Rigidbody.AddForce(new Vector2(Random.Range(-1f,1f), 1) * 550f);
                fruitComponent.IsDrop = true;
            }
        }
    }
}
