using FruitNinja.Components;
using Leopotam.Ecs;

namespace FruitNinja.Systems
{
    public class BladeCutSystem : IEcsRunSystem
    {
        private EcsFilter<FruitComponent> _fruits = null;
        private EcsFilter<BladeComponent> _blades = null;

        public void Run()
        {
            foreach (var fruit in _fruits)
            {
                ref var fruitComponent = ref _fruits.Get1(fruit);
                if(fruitComponent.IsDrop == false || fruitComponent.IsCut)
                    continue;

                foreach (var blade in _blades)
                {
                    ref var bladeComponent = ref _blades.Get1(blade);
                    
                    if (bladeComponent.Collider.Distance(fruitComponent.Collider).isOverlapped)
                    {
                        fruitComponent.IsCut = true;
                    }
                }
            }
        }
    }
}
