using Cooking.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Cooking.Systems
{
    public class IngredientsClickSystem : IEcsRunSystem
    {
        private EcsFilter<IngredientPieceComponent> _filterPiece;
        private EcsFilter<IngredientPlaceComponent> _filterPlaces;

        public void Run()
        {
            if (Input.touchCount <= 0)
                return;

            var touch = Input.GetTouch(0);

            if (touch.phase != TouchPhase.Began &&
                touch.phase != TouchPhase.Moved &&
                touch.phase != TouchPhase.Stationary)
                return;
            
            var clickPos = Camera.main.ScreenToWorldPoint(touch.position);

            foreach (var piece in _filterPiece)
            {
                ref var pieceComponent = ref _filterPiece.Get1(piece);
                if (pieceComponent.Collider.OverlapPoint(clickPos) == false
                || pieceComponent.IsBusy)
                    continue;

                foreach (var place in _filterPlaces)
                {
                    ref var placeComponent = ref _filterPlaces.Get1(place);
                    if(placeComponent.IsBusy)
                        continue;

                    placeComponent.IsBusy = true;
                    pieceComponent.IsBusy = true;
                    pieceComponent.GameObject.transform.position = placeComponent.Position;
                    return;
                }
            }
        }
    }
}
