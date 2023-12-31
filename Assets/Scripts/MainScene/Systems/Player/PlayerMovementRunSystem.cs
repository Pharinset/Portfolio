﻿using UnityEngine;
using Leopotam.Ecs;
using Components.Player;

namespace Systems.Player
{
    public class PlayerMovementRunSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerMovementComponent> _filter = null;
        void IEcsRunSystem.Run()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");

            foreach (var i in _filter)
            {
                var playerMovementComponent = _filter.Get1(i);

                playerMovementComponent.Transform.position +=
                    (new Vector3(horizontal, vertical, 0) * playerMovementComponent.Speed) * Time.deltaTime;
            }
        }
    }
}