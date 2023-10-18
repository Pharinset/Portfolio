using UnityEngine;

namespace FruitNinja.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BladeInitData", menuName = "ScriptableObjects/FruitNinja/BladeInitData", order = 0)]
    public class BladeInitData : ScriptableObject
    {
        [SerializeField] private GameObject bladePrefab;

        public GameObject BladePrefab => bladePrefab;

    }
}
