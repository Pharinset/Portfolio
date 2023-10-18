using Leopotam.Ecs;
using Stove.Components;
using Stove.ScriptableObjects;

namespace Stove.Systems
{
    public class CircleTargetSuccessSystem : IEcsRunSystem
    {
        private EcsFilter<TouchComponent> _touch;
        private EcsFilter<StoveComponent> _stove;
        private EcsFilter<CircleTargetComponent> _circleTarget;

        private StoveInitData _initData;
        private EcsWorld _world;
        public void Run()
        {
            foreach (var touch in _touch)
            {
                ref var touchComponent = ref _touch.Get1(touch);

                foreach (var circle in _circleTarget)
                {
                    ref var circleComponent = ref _circleTarget.Get1(circle);
                    if (circleComponent.Collider.OverlapPoint(touchComponent.Position)
                        && _circleTarget.GetEntity(circle).Has<RotatorComponent>())
                    {
                        var rotator = _circleTarget.GetEntity(circle).Get<RotatorComponent>().Rotator;
                        _circleTarget.GetEntity(circle).Del<RotatorComponent>();
                        CalculateResult(rotator.localRotation.eulerAngles.z);
                    }
                }
            }
        }

        private void CalculateResult(float angle)
        {
            if (_initData.GreenZoneMin < angle && angle < _initData.GreenZoneMax)
            {
                foreach (var stove in _stove)
                {
                    ref var stoveComponent = ref _stove.Get1(stove);
                    stoveComponent.Stove.SetAlphaObj(1);
                }
                return;
            }
            
            if (_initData.RedZoneMin < angle && angle < _initData.RedZoneMax)
            {
                foreach (var stove in _stove)
                {
                    ref var stoveComponent = ref _stove.Get1(stove);
                    stoveComponent.Stove.SetAlphaObj(0.75f);
                }
                return;
            }
        }
    }
}
