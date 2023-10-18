using Leopotam.Ecs;
using Stove.Components;
using UnityEngine;

namespace Stove.Systems
{
    public class RotatorSystem : IEcsRunSystem
    {
        private EcsFilter<RotatorComponent> _rotators;
        public void Run()
        {
            foreach (var rotator in _rotators)
            {
                ref var rotatorComponent = ref _rotators.Get1(rotator);
                rotatorComponent.Rotator.localRotation = Quaternion.Euler(new Vector3(0,0,
                    rotatorComponent.Rotator.rotation.eulerAngles.z + (rotatorComponent.Speed * Time.deltaTime)));
            }
        }
    }
}
