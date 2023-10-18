using UnityEngine;

namespace FruitNinja.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FruitInitData", menuName = "ScriptableObjects/FruitNinja/FruitInitData", order = 0)]
    public class FruitInitData : ScriptableObject
    {
        [SerializeField] private GameObject fruitPrefab;
        [SerializeField] private GameObject fruitHalfPrefab;
        [SerializeField] private Sprite fruit;
        [SerializeField] private Sprite fruitHalf;

        public GameObject FruitPrefab => fruitPrefab;
        public GameObject FruitHalfPrefab => fruitHalfPrefab;
        public Sprite FruitSprite => fruit;
        public Sprite FruitHalfSprite => fruitHalf;

    }
}
