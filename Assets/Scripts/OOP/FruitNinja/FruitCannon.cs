using UnityEngine;
using System.Collections;

namespace OOP.FruitNinja
{
    public class FruitCannon : MonoBehaviour
    {
        [SerializeField] private Fruit fruitPrefab;

        private void Start()
        {
            StartCoroutine(FruitSpawnerNumerator());
        }

        IEnumerator FruitSpawnerNumerator()
        {
            while (true)
            {
                yield return new WaitForSeconds(2f);

                var rb = Instantiate(fruitPrefab.gameObject, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                    rb.AddForce(new Vector2(-1, 1) * 550f);

            }
        }

    }
}
