using Leopotam.Ecs;
using UnityEngine;
using FruitNinja.Components;

namespace FruitNinja.Systems
{
    sealed class BladeRunSystem : IEcsRunSystem
    {
        private EcsFilter<BladeComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var bladeComponent = ref _filter.Get1(i);

                if (Input.touchCount > 0)
                {
                    var touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began ||
                        touch.phase == TouchPhase.Moved ||
                        touch.phase == TouchPhase.Stationary)
                    {
                        bladeComponent.Transform.position = Camera.main.ScreenToWorldPoint(touch.position);
                        continue;
                    }
                }
                
                bladeComponent.Transform.position = new Vector3(-10,-10);
            }
        }
    }
}