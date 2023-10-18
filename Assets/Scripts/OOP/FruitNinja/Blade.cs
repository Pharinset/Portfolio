using UnityEngine;

namespace OOP.FruitNinja
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Blade : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began ||
                    touch.phase == TouchPhase.Moved ||
                    touch.phase == TouchPhase.Stationary)
                {
                    transform.position = Camera.main.ScreenToWorldPoint(touch.position);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Fruit fruit))
                fruit.CutThis();
        }
    }
}
