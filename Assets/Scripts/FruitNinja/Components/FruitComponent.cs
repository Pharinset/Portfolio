using UnityEngine;

namespace FruitNinja.Components
{
    public struct FruitComponent
    {
        public CircleCollider2D Collider;
        public Rigidbody2D Rigidbody;
        public SpriteRenderer SpriteRenderer;
        public bool IsDrop;
        public bool IsCut;
    }
}