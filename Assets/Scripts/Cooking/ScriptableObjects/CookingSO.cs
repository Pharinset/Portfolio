using System;
using UnityEngine;

namespace Cooking.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CookingInitData", menuName = "ScriptableObjects/Cooking/CookingInitData", order = 0)]
    public class CookingSO : ScriptableObject
    {
        [SerializeField] private GameObject _dought;
        [SerializeField] private GameObject _ingredientsParent;

        public GameObject Dought => _dought;
        public GameObject IngredientsParent => _ingredientsParent;
    }
}
