using UnityEngine;

namespace OOP.FruitNinja
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private Fruit croppedFruit;

        [ContextMenu("Crop This")]
        public void CutThis()
        {
            if (croppedFruit == null)
                return;

            var rb1 = Instantiate(croppedFruit.gameObject, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            var rb2 = Instantiate(croppedFruit.gameObject, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();

            rb1.AddForce(new Vector2(0, 0.5f) * 200f);
            rb2.AddForce(new Vector2(1f, 0f) * 200f);

            Destroy(gameObject);
        }
    }
}
