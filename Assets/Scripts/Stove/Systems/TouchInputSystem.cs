using Leopotam.Ecs;
using Stove.Components;
using UnityEngine;

namespace Stove.Systems
{
    public class TouchInputSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        public void Run()
        {
            if (Input.touchCount <= 0)
                return;
            
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began ||
                touch.phase == TouchPhase.Moved ||
                touch.phase == TouchPhase.Stationary)
            {
                var touchEntity = _world.NewEntity();
                ref var touchComponent = ref touchEntity.Get<TouchComponent>();
                touchComponent.Position = Camera.main.ScreenToWorldPoint(touch.position);
            }
            
        }
    }
}
