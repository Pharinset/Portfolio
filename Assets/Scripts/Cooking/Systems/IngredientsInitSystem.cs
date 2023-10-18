using Cooking.Components;
using Cooking.ScriptableObjects;
using Leopotam.Ecs;
using OOP.Cooking;
using UnityEngine;

namespace Cooking.Systems
{
    public class IngredientsInitSystem : IEcsInitSystem
    {
        private CookingSO _initData;
        private EcsWorld _world;
        
        public void Init()
        {
            var doughtGo = Object.Instantiate(_initData.Dought);
            var ingredientsGo = Object.Instantiate(_initData.IngredientsParent);
            var doughtPositions = doughtGo.GetComponent<DoughCooking>().GetPositions();

            foreach (var place in doughtPositions)
            {
                var placeEntity = _world.NewEntity();
                ref var ingredientPlaceComponent = ref placeEntity.Get<IngredientPlaceComponent>();
                ingredientPlaceComponent.Position = place;
            }

            foreach (var transform in ingredientsGo.GetComponent<IngredientsContainer>().ingredients)
            {
                var ingredientEntity = _world.NewEntity();
                ref var ingredientPiece = ref ingredientEntity.Get<IngredientPieceComponent>();
                ingredientPiece.GameObject = transform.gameObject;
                ingredientPiece.Collider = transform.GetComponent<CircleCollider2D>();
            }
            
        }
    }
}
