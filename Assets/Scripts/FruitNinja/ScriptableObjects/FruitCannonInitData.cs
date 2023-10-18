using UnityEngine;

namespace FruitNinja.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FruitCannonInitData", menuName = "ScriptableObjects/FruitNinja/FruitCannonInitData", order = 0)]
    public class FruitCannonInitData : ScriptableObject
    {
        [SerializeField] private GameObject fruitCannonPrefab;

        public GameObject FruitCannonPrefab => fruitCannonPrefab;

    }
}
